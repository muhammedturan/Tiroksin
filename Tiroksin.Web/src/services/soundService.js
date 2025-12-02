// Mario-style Sound Service for Tiroksin Quiz Game

const sounds = {
  select: '/sounds/jump.wav',      // Seçenek seçme
  correct: '/sounds/coin.wav',     // Doğru cevap
  wrong: '/sounds/bunp.wav',       // Yanlış cevap
  victory: '/sounds/powerup.wav',  // Oyun kazanma
  gameStart: '/sounds/kick.wav',   // Oyun başlama
  fireball: '/sounds/fireball.wav' // Ekstra efekt
}

// Audio cache for better performance
const audioCache = {}

// Preload all sounds
export function preloadSounds() {
  Object.entries(sounds).forEach(([key, path]) => {
    const audio = new Audio(path)
    audio.preload = 'auto'
    audioCache[key] = audio
  })
}

// Play a sound effect
export function playSound(soundName, volume = 0.5) {
  try {
    const soundPath = sounds[soundName]
    if (!soundPath) {
      console.warn(`Sound "${soundName}" not found`)
      return
    }

    // Create new Audio instance for overlapping sounds
    const audio = new Audio(soundPath)
    audio.volume = Math.min(1, Math.max(0, volume))
    audio.play().catch(err => {
      // Ignore autoplay errors (user hasn't interacted with page yet)
      if (err.name !== 'NotAllowedError') {
        console.warn('Sound play error:', err)
      }
    })
  } catch (error) {
    console.warn('Sound error:', error)
  }
}

// Convenience functions
export const playSelect = () => playSound('select', 0.4)
export const playCorrect = () => playSound('correct', 0.6)
export const playWrong = () => playSound('wrong', 0.5)
export const playVictory = () => playSound('victory', 0.7)
export const playGameStart = () => playSound('gameStart', 0.5)
export const playFireball = () => playSound('fireball', 0.5)

// Export all sound names for reference
export const soundNames = Object.keys(sounds)

export default {
  preloadSounds,
  playSound,
  playSelect,
  playCorrect,
  playWrong,
  playVictory,
  playGameStart,
  playFireball,
  soundNames
}
