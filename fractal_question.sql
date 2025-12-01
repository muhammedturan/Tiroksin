-- Önce eski soruyu sil
DELETE FROM question_options WHERE question_id IN (
    SELECT id FROM questions WHERE text LIKE '%şekillerden hangisi%'
);
DELETE FROM questions WHERE text LIKE '%şekillerden hangisi%';

-- Resimli şıklı soru ekle (Hayvanlar)
DO $$
DECLARE
    v_user_id UUID;
    v_question_id UUID;
BEGIN
    SELECT id INTO v_user_id FROM users WHERE username = 'turan';

    -- Soru ekle - Hangi hayvan memeli değildir?
    INSERT INTO questions (id, text, difficulty, options_layout, exam_type, created_by, status, is_public, view_count, attempt_count, correct_count, points, created_at, category_pr, subject_pr, topic_pr)
    VALUES (
        gen_random_uuid(),
        '<p><strong>Aşağıdaki hayvanlardan hangisi memeli değildir?</strong></p>',
        0,  -- Easy
        1,  -- Grid layout
        0,  -- TYT
        v_user_id,
        1,  -- Active
        true,
        0, 0, 0, 5,
        NOW(),
        'Biyoloji',
        'Canlılar',
        'Hayvanlar'
    ) RETURNING id INTO v_question_id;

    -- Şıkları ekle - Her şıkta resim var (PNG formatında güvenilir linkler)
    INSERT INTO question_options (id, question_id, option_key, text, is_correct) VALUES
    (gen_random_uuid(), v_question_id, 'A', '<p><img src="https://cdn-icons-png.flaticon.com/128/616/616408.png" alt="Kedi" style="width:80px;height:80px;"></p><p>Kedi</p>', false),
    (gen_random_uuid(), v_question_id, 'B', '<p><img src="https://cdn-icons-png.flaticon.com/128/616/616430.png" alt="Köpek" style="width:80px;height:80px;"></p><p>Köpek</p>', false),
    (gen_random_uuid(), v_question_id, 'C', '<p><img src="https://cdn-icons-png.flaticon.com/128/3069/3069186.png" alt="Kartal" style="width:80px;height:80px;"></p><p>Kartal</p>', true),
    (gen_random_uuid(), v_question_id, 'D', '<p><img src="https://cdn-icons-png.flaticon.com/128/3069/3069172.png" alt="Fil" style="width:80px;height:80px;"></p><p>Fil</p>', false);

    RAISE NOTICE 'Resimli şıklı soru eklendi: %', v_question_id;
END $$;
