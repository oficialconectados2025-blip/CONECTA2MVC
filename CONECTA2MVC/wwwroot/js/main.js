; (() => {
    'use strict'
    const _0xe55e06 = document.getElementById('chat-box-body')
    if (!_0xe55e06) {
        return
    }
    const _0x819cc8 = _0xe55e06.querySelector('.chat-logs'),
        _0x22f81c = _0xe55e06.querySelector('.chat-input form'),
        _0x347f8f = _0xe55e06.querySelector('#chat-input'),
        _0x2b8ed6 = _0xe55e06.querySelector('#chat-circle'),
        _0x21895b = _0xe55e06.querySelector('#chat-box-toggle')
    let _0x3aed84 = 0,
        _0x108e63 = false
    const _0x3683a2 = (_0x53614c) =>
        String(_0x53614c ?? '')
            .replace(/&/g, '&amp;')
            .replace(/</g, '&lt;')
            .replace(/>/g, '&gt;'),
        _0x5019e2 = () =>
            _0x819cc8.scrollTo({
                top: _0x819cc8.scrollHeight,
                behavior: 'smooth',
            }),
        _0x249627 = () => {
            if (_0x108e63) {
                return
            }
            const _0x244bf3 =
                '\n      <div id="typing-msg" class="chat-msg bot">\n        <div class="d-flex align-items-center">\n          <span class="msg-avatar">\n            <img src="assets/img/nicaraguabot.webp" class="avatar avatar-lg" alt="">\n          </span>\n          <div class="typing-indicator"><span></span><span></span><span></span></div>\n        </div>\n      </div>'
            _0x819cc8.insertAdjacentHTML('beforeend', _0x244bf3)
            _0x108e63 = true
            _0x5019e2()
        },
        _0x2b078a = () => {
            if (!_0x108e63) {
                return
            }
            const _0x4199cc = document.getElementById('typing-msg')
            if (_0x4199cc) {
                _0x4199cc.remove()
            }
            _0x108e63 = false
        }
    function _0x44abee(_0x3f6798, _0x1fa4a5) {
        _0x3aed84++
        const _0x1c7388 = new Date().toLocaleTimeString(),
            _0x3f91a2 = _0x1fa4a5 === 'self',
            _0xafe4de = _0x3f91a2 ? 'Tú' : 'Bot',
            _0xbdba64 = _0x3f91a2 ? 'userbot.webp' : 'nicaraguabot.webp',
            _0x163ad7 =
                '\n      <div id="cm-msg-' +
                _0x3aed84 +
                '" class="chat-msg ' +
                _0x1fa4a5 +
                '">\n        <div class="d-flex align-items-center ' +
                (_0x3f91a2 ? 'justify-content-end' : '') +
                '">\n          <div class="mx-10">\n            <a href="#" class="text-dark hover-primary fw-bold">' +
                _0xafe4de +
                '</a>\n            <p class="text-muted fs-12 mb-0">' +
                _0x1c7388 +
                '</p>\n          </div>\n          <span class="msg-avatar">\n            <img src="assets/img/' +
                _0xbdba64 +
                '" class="avatar avatar-lg" alt="">\n          </span>\n        </div>\n        <div class="cm-msg-text">' +
                _0x3683a2(_0x3f6798) +
                '</div>\n      </div>'
        _0x819cc8.insertAdjacentHTML('beforeend', _0x163ad7)
        _0x5019e2()
        if (_0x3f91a2) {
            _0x347f8f.value = ''
        }
    }
    const _0x15e273 = (_0x29deb8, _0x5cdf1a = {}, _0x395f86 = 15000) =>
        Promise.race([
            fetch(_0x29deb8, _0x5cdf1a),
            new Promise((_0x13350d, _0x4c21e6) =>
                setTimeout(() => _0x4c21e6(new Error('timeout')), _0x395f86)
            ),
        ])
    async function _0x56f217(_0x40d58f) {
        const _0x15afbd = {
            message: _0x40d58f,
            timezone: Intl.DateTimeFormat().resolvedOptions().timeZone,
            resolution: window.screen.width + 'x' + window.screen.height,
            user_agent: navigator.userAgent,
        }
        _0x249627()
        try {
            const _0x2b6ad1 = await _0x15e273(
                '/chatbot',
                {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/json' },
                    body: JSON.stringify(_0x15afbd),
                },
                20000
            )
            if (!_0x2b6ad1.ok) {
                throw new Error('bad_status_' + _0x2b6ad1.status)
            }
            const _0x100fa6 = await _0x2b6ad1.json()
            _0x2b078a()
            _0x44abee(String(_0x100fa6.bot_reply ?? '\u2026'), 'user')
        } catch (_0x335b8a) {
            console.error(_0x335b8a)
            _0x2b078a()
            _0x44abee(
                'No pude contactar al servidor ahora mismo. Intenta nuevamente.',
                'user'
            )
        }
    }
    _0x22f81c.addEventListener('submit', (_0x1a731b) => {
        _0x1a731b.preventDefault()
        const _0x3e016b = _0x347f8f.value.trim()
        if (!_0x3e016b) {
            return
        }
        _0x44abee(_0x3e016b, 'self')
        _0x56f217(_0x3e016b)
    })
    const _0x53f538 = () => {
        _0xe55e06.classList.toggle('show')
        _0xe55e06.classList.contains('show') &&
            setTimeout(() => _0x347f8f?.focus(), 120)
    }
    _0x2b8ed6.addEventListener('click', _0x53f538)
    _0x21895b.addEventListener('click', _0x53f538)
    document.addEventListener('keydown', (_0x4fa9f1) => {
        if (_0x4fa9f1.key === 'Escape' && _0xe55e06.classList.contains('show')) {
            _0x53f538()
        }
    })
})()
; (() => {
    document.documentElement.classList.add('is-loading')
    const _0x44c34b = document.getElementById('loading-screen')
    if (!_0x44c34b) {
        document.documentElement.classList.remove('is-loading')
        return
    }
    const _0x228e6e = _0x44c34b.querySelector('.thermo-fill'),
          _0xa5e6ec = _0x44c34b.querySelector('#thermoPercent'),
          _orbit   = _0x44c34b.querySelector('.loader-orbit')   // 🔥 cohete

    if (!_0x228e6e || !_0xa5e6ec) {
        _0x44c34b.classList.add('is-done')
        document.documentElement.classList.remove('is-loading')
        return
    }
    const _0x133889 = 2 * Math.PI * 52
    _0x228e6e.style.strokeDasharray = String(_0x133889)
    _0x228e6e.style.strokeDashoffset = String(_0x133889)
    let _0x12617b = 0,
        _0x3ece49 = 92,
        _0x31d88e = false,
        _0x423cd1 = null,
        _0x256782 = false
    const _0xabfc64 = (_0x54dc5b, _0x89151a, _0x49dd77) =>
            Math.min(_0x49dd77, Math.max(_0x89151a, _0x54dc5b)),
        _0x2717f4 = (_0x454caa) => {
            const _0x442820 = _0xabfc64(Math.round(_0x454caa), 0, 100)

            // círculo de fuego
            _0x228e6e.style.strokeDashoffset = String(
                _0x133889 * (1 - _0x442820 / 100)
            )
            _0xa5e6ec.textContent = _0x442820 + '%'

            // 🔥🚀 ROTAR COHETE SEGÚN EL PORCENTAJE
            if (_orbit) {
                const _angle = (_0x442820 / 100) * 360
                _orbit.style.transform = `rotate(${_angle}deg)`
            }
        },
        _0x4c43fc = window.matchMedia ? ('(prefers-reduced-motion: reduce)')?.matches : false,
        _0x5be889 = () => {
            if (_0x256782) {
                return
            }
            _0x256782 = true
            cancelAnimationFrame(_0x423cd1)
            _0x2717f4(100)
            _0x44c34b.classList.add('is-done')
            document.documentElement.classList.remove('is-loading')
            setTimeout(
                () =>
                    _0x44c34b.parentNode && _0x44c34b.parentNode.removeChild(_0x44c34b),
                600
            )
        },
        _0xce477b = () => {
            _0x12617b += (_0x3ece49 - _0x12617b) * 0.08
            _0x2717f4(_0x12617b)
            if (_0x31d88e && (_0x12617b >= 99.5 || _0x4c43fc)) {
                _0x5be889()
                return
            }
            _0x423cd1 = requestAnimationFrame(_0xce477b)
        }
    _0x423cd1 = requestAnimationFrame(_0xce477b)
    window.addEventListener(
        'load',
        () => {
            _0x31d88e = true
            _0x3ece49 = 100
            if (_0x4c43fc) {
                _0x5be889()
                return
            }
            if (_0x12617b < 70) {
                _0x12617b = 70
            }
            setTimeout(() => {
                _0x3ece49 = 100
            }, 80)
        },
        {
            once: true,
            passive: true,
        }
    )
    setTimeout(() => {
        !_0x31d88e && ((_0x31d88e = true), (_0x3ece49 = 100))
    }, 8000)
})()
; (() => {
    const _0x1a66ca = document.getElementById('drawer'),
        _0x150d73 = document.getElementById('scrim'),
        _0x327ea6 = document.getElementById('hamburger'),
        _0x14d188 = document.getElementById('drawerClose'),
        _0x3a3726 = 'a[href],button:not([disabled]),[tabindex]:not([tabindex="-1"])'
    let _0x5586bf = null
    const _0x57dfcb =
        document.querySelector('.app-header') || document.querySelector('header')
    _0x57dfcb &&
        (_0x57dfcb.contains(_0x1a66ca) || _0x57dfcb.contains(_0x150d73)) &&
        (document.body.appendChild(_0x150d73), document.body.appendChild(_0x1a66ca))
    function _0x20b8c1() {
        _0x5586bf = document.activeElement
        _0x1a66ca.classList.add('is-open')
        _0x150d73.hidden = false
        requestAnimationFrame(() => _0x150d73.classList.add('is-visible'))
        document.body.classList.add('no-scroll')
        _0x1a66ca.setAttribute('aria-hidden', 'false')
        _0x327ea6?.setAttribute('aria-expanded', 'true')
        const _0x1c74fb = _0x1a66ca.querySelector(_0x3a3726)
        _0x1c74fb && _0x1c74fb.focus()
        document.addEventListener('keydown', _0x46c017)
        _0x150d73.addEventListener('click', _0x3fb0f7, { once: true })
    }
    function _0x3fb0f7() {
        _0x1a66ca.classList.remove('is-open')
        _0x150d73.classList.remove('is-visible')
        document.body.classList.remove('no-scroll')
        _0x1a66ca.setAttribute('aria-hidden', 'true')
        _0x327ea6?.setAttribute('aria-expanded', 'false')
        setTimeout(() => {
            _0x150d73.hidden = true
        }, 200)
        document.removeEventListener('keydown', _0x46c017)
        _0x5586bf && _0x5586bf.focus()
    }
    function _0x46c017(_0x49112e) {
        if (_0x49112e.key === 'Escape') {
            _0x49112e.preventDefault()
            _0x3fb0f7()
            return
        }
        if (_0x49112e.key === 'Tab') {
            const _0x5ac615 = [..._0x1a66ca.querySelectorAll(_0x3a3726)]
            if (!_0x5ac615.length) {
                return
            }
            const _0x2ed504 = _0x5ac615[0],
                _0x49e8ee = _0x5ac615[_0x5ac615.length - 1]
            if (_0x49112e.shiftKey && document.activeElement === _0x2ed504) {
                _0x49112e.preventDefault()
                _0x49e8ee.focus()
            } else {
                !_0x49112e.shiftKey &&
                    document.activeElement === _0x49e8ee &&
                    (_0x49112e.preventDefault(), _0x2ed504.focus())
            }
        }
    }
    _0x327ea6?.addEventListener('click', () => {
        const _0x4b9575 = _0x327ea6.getAttribute('aria-expanded') === 'true'
        _0x4b9575 ? _0x3fb0f7() : _0x20b8c1()
    })
    _0x14d188?.addEventListener('click', _0x3fb0f7)
    _0x1a66ca.addEventListener('click', (_0x3eeb68) => {
        if (_0x3eeb68.target.closest('a')) {
            _0x3fb0f7()
        }
    })
})()
const Slider = (() => {
    function _0x586075(_0x1cbf08 = '.slider', _0x2c9230 = {}) {
        const _0x3ce631 = document.querySelector(_0x1cbf08)
        if (!_0x3ce631) {
            return console.warn('Slider: no se encontró', _0x1cbf08)
        }
        return new _0x2ad619(_0x3ce631, _0x2c9230)
    }
    function _0x22107f(_0x43bcee = '.slider', _0x51cdae = {}) {
        return [...document.querySelectorAll(_0x43bcee)].map(
            (_0x2a29b6) => new _0x2ad619(_0x2a29b6, _0x51cdae)
        )
    }
    class _0x2ad619 {
        constructor(_0x71e852, _0x217f95 = {}) {
            this.root = _0x71e852
            this.track = _0x71e852.querySelector('.slides')
            this.prevBtn = _0x71e852.querySelector('.nav-arrow.prev')
            this.nextBtn = _0x71e852.querySelector('.nav-arrow.next')
            this.dots = [..._0x71e852.querySelectorAll('.nav-dot')]
            this.realSlides = [...this.track.querySelectorAll('.slide')]
            if (!this.track || !this.realSlides.length) {
                throw new Error('Slider: faltan .slides/.slide')
            }
            this.opts = Object.assign(
                {
                    autoplay: true,
                    interval: 5000,
                    pauseOnHover: true,
                    keyboard: true,
                    infinite: true,
                    visibilityThreshold: 0.5,
                },
                _0x217f95
            )
            this.timer = null
            this.isAnimating = false
            this.total = this.realSlides.length
            this.idx = 1
            this.inViewport = true
            this.hoverBound = false
            this['_onTransitionEnd'] = this['_onTransitionEnd'].bind(this)
            this['_onVisibility'] = this['_onVisibility'].bind(this)
            this['_onIO'] = this['_onIO'].bind(this)
            this['_buildClones']()
            this.slidesAll = [...this.track.querySelectorAll('.slide')]
            this.originalTransition =
                getComputedStyle(this.track).transition || 'transform 0.5s ease'
            this.track.style.transition = 'none'
            this['_applyTransform']()
            void this.track.offsetHeight
            this.track.style.transition = this.originalTransition
            if (this.opts.keyboard) {
                if (!this.root.hasAttribute('tabindex')) {
                    this.root.setAttribute('tabindex', '0')
                }
                this.root.setAttribute('role', 'region')
                this.root.setAttribute('aria-label', 'Carrusel de diapositivas')
            }
            this['_bindEvents']()
            this['_updateDots']()
            if (this.opts.autoplay) {
                this['_kickAutoplay']()
            }
            this['_observeViewport']()
            window.addEventListener('load', () => this['_kickAutoplay'](), {
                once: true,
            })
            window.addEventListener('app:ready', () => this['_kickAutoplay'](), {
                once: true,
            })
        }
        ['_buildClones']() {
            if (!this.opts.infinite || this.realSlides.length < 2) {
                return
            }
            const _0x24e2c9 = this.realSlides[0].cloneNode(true),
                _0x29cf94 = this.realSlides[this.realSlides.length - 1].cloneNode(true)
            _0x24e2c9.classList.add('clone')
            _0x29cf94.classList.add('clone')
            this.track.insertBefore(_0x29cf94, this.realSlides[0])
            this.track.appendChild(_0x24e2c9)
        }
        ['_applyTransform']() {
            this.track.style.transform = 'translateX(-' + 100 * this.idx + '%)'
        }
        ['_updateDots']() {
            if (!this.dots.length) {
                return
            }
            const _0xceef0f = (this.idx - 1 + this.total) % this.total
            this.dots.forEach((_0x58de82, _0x3cf975) => {
                _0x58de82.classList.toggle('active', _0x3cf975 === _0xceef0f)
                _0x58de82.setAttribute(
                    'aria-current',
                    _0x3cf975 === _0xceef0f ? 'true' : 'false'
                )
            })
        }
        ['_goTo'](_0x8be7a5) {
            if (this.isAnimating) {
                return
            }
            this.isAnimating = true
            this.idx = _0x8be7a5
            this.track.style.transition = this.originalTransition
            this['_applyTransform']()
            this['_updateDots']()
        }
        ['next']() {
            this['_goTo'](this.idx + 1)
        }
        ['prev']() {
            this['_goTo'](this.idx - 1)
        }
        ['_onTransitionEnd'](_0x492d65) {
            if (
                _0x492d65.target !== this.track ||
                _0x492d65.propertyName !== 'transform'
            ) {
                return
            }
            const _0x3ef8fc = this.slidesAll[this.idx]
            if (_0x3ef8fc && _0x3ef8fc.classList.contains('clone')) {
                this.track.style.transition = 'none'
                if (this.idx === 0) {
                    this.idx = this.total
                } else {
                    if (this.idx === this.slidesAll.length - 1) {
                        this.idx = 1
                    }
                }
                this['_applyTransform']()
                void this.track.offsetHeight
                this.track.style.transition = this.originalTransition
            }
            this.isAnimating = false
        }
        ['_kickAutoplay']() {
            this['_stopAutoplay']()
            if (!this.opts.autoplay) {
                return
            }
            this.timer = setInterval(() => this.next(), this.opts.interval)
        }
        ['_stopAutoplay']() {
            this.timer && (clearInterval(this.timer), (this.timer = null))
        }
        ['restartAutoplay']() {
            this['_kickAutoplay']()
        }
        ['_onVisibility']() {
            if (document.hidden) {
                this['_stopAutoplay']()
            } else {
                this['_kickAutoplay']()
            }
        }
        ['_bindEvents']() {
            this.track.addEventListener('transitionend', this['_onTransitionEnd'])
            if (this.prevBtn) {
                this.prevBtn.addEventListener('click', () => {
                    this.prev()
                    this['_kickAutoplay']()
                })
            }
            if (this.nextBtn) {
                this.nextBtn.addEventListener('click', () => {
                    this.next()
                    this['_kickAutoplay']()
                })
            }
            this.dots.length &&
                this.dots.forEach((_0x1d2d9b, _0x59da22) => {
                    _0x1d2d9b.addEventListener('click', () => {
                        this['_goTo'](_0x59da22 + 1)
                        this['_kickAutoplay']()
                    })
                })
            if (
                this.opts.pauseOnHover &&
                window.matchMedia('(hover: hover)').matches
            ) {
                const _0x357adc = () => {
                    if (this.hoverBound) {
                        return
                    }
                    this.hoverBound = true
                    this.root.addEventListener('mouseenter', () =>
                        this['_stopAutoplay']()
                    )
                    this.root.addEventListener('mouseleave', () =>
                        this['_kickAutoplay']()
                    )
                }
                window.addEventListener('pointermove', _0x357adc, {
                    once: true,
                    passive: true,
                })
            }
            this.opts.keyboard &&
                this.root.addEventListener('keydown', (_0x5ea40e) => {
                    _0x5ea40e.key === 'ArrowRight' &&
                        (_0x5ea40e.preventDefault(), this.next(), this['_kickAutoplay']())
                    _0x5ea40e.key === 'ArrowLeft' &&
                        (_0x5ea40e.preventDefault(), this.prev(), this['_kickAutoplay']())
                })
            document.addEventListener('visibilitychange', this['_onVisibility'], {
                passive: true,
            })
        }
        ['_observeViewport']() {
            if (!('IntersectionObserver' in window)) {
                return
            }
            this.io = new IntersectionObserver(this['_onIO'], {
                root: null,
                threshold: this.opts.visibilityThreshold,
            })
            this.io.observe(this.root)
        }
        ['_onIO'](_0x440eb6) {
            const _0xb282d2 = _0x440eb6[0].isIntersecting
            if (_0xb282d2) {
                this['_kickAutoplay']()
            } else {
                this['_stopAutoplay']()
            }
        }
    }
    return {
        init: _0x586075,
        initAll: _0x22107f,
    }
})()
document.addEventListener(
    'click',
    (_0x55316c) => {
        const _0x2b67c4 = _0x55316c.target.closest('a.card-link[data-video]')
        if (!_0x2b67c4) {
            return
        }
        const _0x2c62b0 = _0x2b67c4.dataset.video
        if (_0x2c62b0) {
            sessionStorage.setItem('videoId', _0x2c62b0)
        }
    },
    { capture: true }
)
document.addEventListener('DOMContentLoaded', () => {
    window['_slider'] = Slider.init('.slider', {
        autoplay: true,
        interval: 5000,
        pauseOnHover: true,
        keyboard: true,
        infinite: true,
        visibilityThreshold: 0.5,
    })
})
