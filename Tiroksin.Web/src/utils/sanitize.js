import DOMPurify from 'dompurify'

/**
 * HTML içeriğini XSS saldırılarına karşı temizler.
 *
 * DOMPurify nedir?
 * - Güvenilmeyen HTML'i temizleyen bir kütüphane
 * - <script> taglerini, onclick gibi event handler'ları kaldırır
 * - Sadece güvenli HTML taglerini (p, b, i, img, span, div vb.) bırakır
 *
 * Neden gerekli?
 * - Veritabanından gelen veriler kötü amaçlı kod içerebilir
 * - v-html direktifi bu kodu doğrudan çalıştırır
 * - DOMPurify bu tehlikeli kodları temizler
 *
 * Örnek:
 * Input:  "<p>Merhaba</p><script>alert('hack')</script>"
 * Output: "<p>Merhaba</p>"
 *
 * @param {string} html - Temizlenecek HTML string
 * @returns {string} - Temizlenmiş güvenli HTML
 */
export function sanitizeHtml(html) {
  if (!html) return ''

  return DOMPurify.sanitize(html, {
    // Matematik formülleri için gereken bazı tagları izin ver
    ALLOWED_TAGS: [
      'p', 'br', 'b', 'i', 'u', 'strong', 'em', 'sub', 'sup',
      'span', 'div', 'img', 'table', 'tr', 'td', 'th', 'thead', 'tbody',
      'ul', 'ol', 'li', 'pre', 'code', 'blockquote', 'h1', 'h2', 'h3', 'h4', 'h5', 'h6',
      'a', 'hr', 'mark', 'del', 'ins', 'figure', 'figcaption',
      // Matematik için
      'math', 'mi', 'mo', 'mn', 'ms', 'mtext', 'mspace', 'mrow', 'mfrac',
      'msqrt', 'mroot', 'msub', 'msup', 'msubsup', 'munder', 'mover', 'munderover'
    ],
    ALLOWED_ATTR: [
      'class', 'id', 'style', 'src', 'alt', 'href', 'target', 'rel',
      'colspan', 'rowspan', 'width', 'height', 'title'
    ],
    // javascript: protokolünü engelle (linkler için)
    FORBID_ATTR: ['onerror', 'onload', 'onclick', 'onmouseover'],
    // Data URI'leri engelle (img src="data:..." ile XSS)
    ALLOW_DATA_ATTR: false
  })
}

/**
 * Vue directive olarak kullanım için
 * Kullanım: v-safe-html="htmlContent"
 */
export const safeHtmlDirective = {
  mounted(el, binding) {
    el.innerHTML = sanitizeHtml(binding.value)
  },
  updated(el, binding) {
    el.innerHTML = sanitizeHtml(binding.value)
  }
}
