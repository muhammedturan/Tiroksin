-- 10 yeni soru ekle (4-13 arası)
-- MuhammedUserId: cdce62f1-cdf8-4ca7-9e56-a5f85303cee6

-- Soru 4: Matematik - Yüzde
INSERT INTO questions (id, text, image_url, options_layout, exam_type, difficulty, category_pr, subject_pr, topic_pr, status, is_public, view_count, attempt_count, correct_count, points, created_at, updated_at, created_by, updated_by)
VALUES
('eeeeeeee-4444-4444-4444-444444444444', 'Bir ürünün fiyatı %20 artırıldıktan sonra yeni fiyat 240 TL olmuştur. Ürünün eski fiyatı kaç TL idi?', NULL, 0, 0, 1, '1', '1', '1', 1, true, 0, 0, 0, 3, NOW(), NOW(), 'cdce62f1-cdf8-4ca7-9e56-a5f85303cee6', NULL);

INSERT INTO question_options (id, question_id, option_key, text, image_url, is_correct)
VALUES
('00000001-0004-0004-0004-000000000001', 'eeeeeeee-4444-4444-4444-444444444444', 'A', '180 TL', NULL, false),
('00000001-0004-0004-0004-000000000002', 'eeeeeeee-4444-4444-4444-444444444444', 'B', '192 TL', NULL, false),
('00000001-0004-0004-0004-000000000003', 'eeeeeeee-4444-4444-4444-444444444444', 'C', '200 TL', NULL, true),
('00000001-0004-0004-0004-000000000004', 'eeeeeeee-4444-4444-4444-444444444444', 'D', '210 TL', NULL, false),
('00000001-0004-0004-0004-000000000005', 'eeeeeeee-4444-4444-4444-444444444444', 'E', '220 TL', NULL, false);

-- Soru 5: Matematik - Oran Orantı
INSERT INTO questions (id, text, image_url, options_layout, exam_type, difficulty, category_pr, subject_pr, topic_pr, status, is_public, view_count, attempt_count, correct_count, points, created_at, updated_at, created_by, updated_by)
VALUES
('eeeeeeee-5555-5555-5555-555555555555', 'Bir işi 6 işçi 12 günde bitiriyor. Aynı işi 9 işçi kaç günde bitirir?', NULL, 0, 0, 1, '1', '1', '1', 1, true, 0, 0, 0, 3, NOW(), NOW(), 'cdce62f1-cdf8-4ca7-9e56-a5f85303cee6', NULL);

INSERT INTO question_options (id, question_id, option_key, text, image_url, is_correct)
VALUES
('00000001-0005-0005-0005-000000000001', 'eeeeeeee-5555-5555-5555-555555555555', 'A', '6 gün', NULL, false),
('00000001-0005-0005-0005-000000000002', 'eeeeeeee-5555-5555-5555-555555555555', 'B', '8 gün', NULL, true),
('00000001-0005-0005-0005-000000000003', 'eeeeeeee-5555-5555-5555-555555555555', 'C', '9 gün', NULL, false),
('00000001-0005-0005-0005-000000000004', 'eeeeeeee-5555-5555-5555-555555555555', 'D', '10 gün', NULL, false),
('00000001-0005-0005-0005-000000000005', 'eeeeeeee-5555-5555-5555-555555555555', 'E', '18 gün', NULL, false);

-- Soru 6: Matematik - Üslü Sayılar
INSERT INTO questions (id, text, image_url, options_layout, exam_type, difficulty, category_pr, subject_pr, topic_pr, status, is_public, view_count, attempt_count, correct_count, points, created_at, updated_at, created_by, updated_by)
VALUES
('eeeeeeee-6666-6666-6666-666666666666', '2³ x 2² işleminin sonucu kaçtır?', NULL, 0, 0, 0, '1', '1', '1', 1, true, 0, 0, 0, 2, NOW(), NOW(), 'cdce62f1-cdf8-4ca7-9e56-a5f85303cee6', NULL);

INSERT INTO question_options (id, question_id, option_key, text, image_url, is_correct)
VALUES
('00000001-0006-0006-0006-000000000001', 'eeeeeeee-6666-6666-6666-666666666666', 'A', '16', NULL, false),
('00000001-0006-0006-0006-000000000002', 'eeeeeeee-6666-6666-6666-666666666666', 'B', '20', NULL, false),
('00000001-0006-0006-0006-000000000003', 'eeeeeeee-6666-6666-6666-666666666666', 'C', '32', NULL, true),
('00000001-0006-0006-0006-000000000004', 'eeeeeeee-6666-6666-6666-666666666666', 'D', '64', NULL, false),
('00000001-0006-0006-0006-000000000005', 'eeeeeeee-6666-6666-6666-666666666666', 'E', '10', NULL, false);

-- Soru 7: Matematik - Çarpanlara Ayırma
INSERT INTO questions (id, text, image_url, options_layout, exam_type, difficulty, category_pr, subject_pr, topic_pr, status, is_public, view_count, attempt_count, correct_count, points, created_at, updated_at, created_by, updated_by)
VALUES
('eeeeeeee-7777-7777-7777-777777777777', 'x² - 9 ifadesinin çarpanlarına ayrılmış hali nedir?', NULL, 0, 0, 1, '1', '2', '2', 1, true, 0, 0, 0, 3, NOW(), NOW(), 'cdce62f1-cdf8-4ca7-9e56-a5f85303cee6', NULL);

INSERT INTO question_options (id, question_id, option_key, text, image_url, is_correct)
VALUES
('00000001-0007-0007-0007-000000000001', 'eeeeeeee-7777-7777-7777-777777777777', 'A', '(x-3)(x-3)', NULL, false),
('00000001-0007-0007-0007-000000000002', 'eeeeeeee-7777-7777-7777-777777777777', 'B', '(x+3)(x+3)', NULL, false),
('00000001-0007-0007-0007-000000000003', 'eeeeeeee-7777-7777-7777-777777777777', 'C', '(x-3)(x+3)', NULL, true),
('00000001-0007-0007-0007-000000000004', 'eeeeeeee-7777-7777-7777-777777777777', 'D', '(x-9)(x+1)', NULL, false),
('00000001-0007-0007-0007-000000000005', 'eeeeeeee-7777-7777-7777-777777777777', 'E', '(x+9)(x-1)', NULL, false);

-- Soru 8: Matematik - Üçgen Özellikleri
INSERT INTO questions (id, text, image_url, options_layout, exam_type, difficulty, category_pr, subject_pr, topic_pr, status, is_public, view_count, attempt_count, correct_count, points, created_at, updated_at, created_by, updated_by)
VALUES
('eeeeeeee-8888-8888-8888-888888888888', 'Bir üçgenin iç açıları toplamı kaç derecedir?', NULL, 0, 0, 0, '1', '3', '3', 1, true, 0, 0, 0, 2, NOW(), NOW(), 'cdce62f1-cdf8-4ca7-9e56-a5f85303cee6', NULL);

INSERT INTO question_options (id, question_id, option_key, text, image_url, is_correct)
VALUES
('00000001-0008-0008-0008-000000000001', 'eeeeeeee-8888-8888-8888-888888888888', 'A', '90°', NULL, false),
('00000001-0008-0008-0008-000000000002', 'eeeeeeee-8888-8888-8888-888888888888', 'B', '120°', NULL, false),
('00000001-0008-0008-0008-000000000003', 'eeeeeeee-8888-8888-8888-888888888888', 'C', '180°', NULL, true),
('00000001-0008-0008-0008-000000000004', 'eeeeeeee-8888-8888-8888-888888888888', 'D', '270°', NULL, false),
('00000001-0008-0008-0008-000000000005', 'eeeeeeee-8888-8888-8888-888888888888', 'E', '360°', NULL, false);

-- Soru 9: Matematik - Ortalama
INSERT INTO questions (id, text, image_url, options_layout, exam_type, difficulty, category_pr, subject_pr, topic_pr, status, is_public, view_count, attempt_count, correct_count, points, created_at, updated_at, created_by, updated_by)
VALUES
('eeeeeeee-9999-9999-9999-999999999999', '4, 8, 12, 16 sayılarının aritmetik ortalaması kaçtır?', NULL, 0, 0, 0, '1', '1', '1', 1, true, 0, 0, 0, 2, NOW(), NOW(), 'cdce62f1-cdf8-4ca7-9e56-a5f85303cee6', NULL);

INSERT INTO question_options (id, question_id, option_key, text, image_url, is_correct)
VALUES
('00000001-0009-0009-0009-000000000001', 'eeeeeeee-9999-9999-9999-999999999999', 'A', '8', NULL, false),
('00000001-0009-0009-0009-000000000002', 'eeeeeeee-9999-9999-9999-999999999999', 'B', '10', NULL, true),
('00000001-0009-0009-0009-000000000003', 'eeeeeeee-9999-9999-9999-999999999999', 'C', '12', NULL, false),
('00000001-0009-0009-0009-000000000004', 'eeeeeeee-9999-9999-9999-999999999999', 'D', '14', NULL, false),
('00000001-0009-0009-0009-000000000005', 'eeeeeeee-9999-9999-9999-999999999999', 'E', '40', NULL, false);

-- Soru 10: Matematik - EBOB-EKOK
INSERT INTO questions (id, text, image_url, options_layout, exam_type, difficulty, category_pr, subject_pr, topic_pr, status, is_public, view_count, attempt_count, correct_count, points, created_at, updated_at, created_by, updated_by)
VALUES
('eeeeeeee-aaaa-aaaa-aaaa-aaaaaaaaaaaa', '12 ve 18 sayılarının EBOB değeri kaçtır?', NULL, 0, 0, 1, '1', '1', '1', 1, true, 0, 0, 0, 3, NOW(), NOW(), 'cdce62f1-cdf8-4ca7-9e56-a5f85303cee6', NULL);

INSERT INTO question_options (id, question_id, option_key, text, image_url, is_correct)
VALUES
('00000001-000a-000a-000a-000000000001', 'eeeeeeee-aaaa-aaaa-aaaa-aaaaaaaaaaaa', 'A', '2', NULL, false),
('00000001-000a-000a-000a-000000000002', 'eeeeeeee-aaaa-aaaa-aaaa-aaaaaaaaaaaa', 'B', '3', NULL, false),
('00000001-000a-000a-000a-000000000003', 'eeeeeeee-aaaa-aaaa-aaaa-aaaaaaaaaaaa', 'C', '6', NULL, true),
('00000001-000a-000a-000a-000000000004', 'eeeeeeee-aaaa-aaaa-aaaa-aaaaaaaaaaaa', 'D', '9', NULL, false),
('00000001-000a-000a-000a-000000000005', 'eeeeeeee-aaaa-aaaa-aaaa-aaaaaaaaaaaa', 'E', '36', NULL, false);

-- Soru 11: Matematik - Karekok
INSERT INTO questions (id, text, image_url, options_layout, exam_type, difficulty, category_pr, subject_pr, topic_pr, status, is_public, view_count, attempt_count, correct_count, points, created_at, updated_at, created_by, updated_by)
VALUES
('eeeeeeee-bbbb-bbbb-bbbb-bbbbbbbbbbbb', '√144 işleminin sonucu kaçtır?', NULL, 0, 0, 0, '1', '1', '1', 1, true, 0, 0, 0, 2, NOW(), NOW(), 'cdce62f1-cdf8-4ca7-9e56-a5f85303cee6', NULL);

INSERT INTO question_options (id, question_id, option_key, text, image_url, is_correct)
VALUES
('00000001-000b-000b-000b-000000000001', 'eeeeeeee-bbbb-bbbb-bbbb-bbbbbbbbbbbb', 'A', '10', NULL, false),
('00000001-000b-000b-000b-000000000002', 'eeeeeeee-bbbb-bbbb-bbbb-bbbbbbbbbbbb', 'B', '11', NULL, false),
('00000001-000b-000b-000b-000000000003', 'eeeeeeee-bbbb-bbbb-bbbb-bbbbbbbbbbbb', 'C', '12', NULL, true),
('00000001-000b-000b-000b-000000000004', 'eeeeeeee-bbbb-bbbb-bbbb-bbbbbbbbbbbb', 'D', '13', NULL, false),
('00000001-000b-000b-000b-000000000005', 'eeeeeeee-bbbb-bbbb-bbbb-bbbbbbbbbbbb', 'E', '14', NULL, false);

-- Soru 12: Matematik - Denklem Çözme
INSERT INTO questions (id, text, image_url, options_layout, exam_type, difficulty, category_pr, subject_pr, topic_pr, status, is_public, view_count, attempt_count, correct_count, points, created_at, updated_at, created_by, updated_by)
VALUES
('eeeeeeee-cccc-cccc-cccc-cccccccccccc', '3x + 5 = 20 denkleminde x kaçtır?', NULL, 0, 0, 0, '1', '2', '2', 1, true, 0, 0, 0, 2, NOW(), NOW(), 'cdce62f1-cdf8-4ca7-9e56-a5f85303cee6', NULL);

INSERT INTO question_options (id, question_id, option_key, text, image_url, is_correct)
VALUES
('00000001-000c-000c-000c-000000000001', 'eeeeeeee-cccc-cccc-cccc-cccccccccccc', 'A', '3', NULL, false),
('00000001-000c-000c-000c-000000000002', 'eeeeeeee-cccc-cccc-cccc-cccccccccccc', 'B', '4', NULL, false),
('00000001-000c-000c-000c-000000000003', 'eeeeeeee-cccc-cccc-cccc-cccccccccccc', 'C', '5', NULL, true),
('00000001-000c-000c-000c-000000000004', 'eeeeeeee-cccc-cccc-cccc-cccccccccccc', 'D', '6', NULL, false),
('00000001-000c-000c-000c-000000000005', 'eeeeeeee-cccc-cccc-cccc-cccccccccccc', 'E', '7', NULL, false);

-- Soru 13: Matematik - Çember
INSERT INTO questions (id, text, image_url, options_layout, exam_type, difficulty, category_pr, subject_pr, topic_pr, status, is_public, view_count, attempt_count, correct_count, points, created_at, updated_at, created_by, updated_by)
VALUES
('eeeeeeee-dddd-dddd-dddd-dddddddddddd', 'Yarıçapı 7 cm olan bir çemberin çevresi kaç cm dir? (π = 22/7)', NULL, 0, 0, 1, '1', '3', '3', 1, true, 0, 0, 0, 3, NOW(), NOW(), 'cdce62f1-cdf8-4ca7-9e56-a5f85303cee6', NULL);

INSERT INTO question_options (id, question_id, option_key, text, image_url, is_correct)
VALUES
('00000001-000d-000d-000d-000000000001', 'eeeeeeee-dddd-dddd-dddd-dddddddddddd', 'A', '22 cm', NULL, false),
('00000001-000d-000d-000d-000000000002', 'eeeeeeee-dddd-dddd-dddd-dddddddddddd', 'B', '36 cm', NULL, false),
('00000001-000d-000d-000d-000000000003', 'eeeeeeee-dddd-dddd-dddd-dddddddddddd', 'C', '44 cm', NULL, true),
('00000001-000d-000d-000d-000000000004', 'eeeeeeee-dddd-dddd-dddd-dddddddddddd', 'D', '49 cm', NULL, false),
('00000001-000d-000d-000d-000000000005', 'eeeeeeee-dddd-dddd-dddd-dddddddddddd', 'E', '154 cm', NULL, false);
