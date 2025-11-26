// =========================================================
// 1) Drawer principal (hamburger + scrim)
// =========================================================
; (() => {
    const drawer = document.getElementById('drawer')
    const scrim = document.getElementById('scrim')
    const hamburger = document.getElementById('hamburger')
    const drawerClose = document.getElementById('drawerClose')

    let lastFocusedElement = null

    const header =
        document.querySelector('.app-header') || document.querySelector('header')

    // Si drawer/scrim están dentro del header, los movemos al body
    if (header && (header.contains(drawer) || header.contains(scrim))) {
        document.body.appendChild(scrim)
        document.body.appendChild(drawer)
    }

    const FOCUSABLE_SELECTOR =
        'a[href],button:not([disabled]),[tabindex]:not([tabindex="-1"])'

    function openDrawer() {
        lastFocusedElement = document.activeElement

        drawer.classList.add('is-open')
        scrim.hidden = false

        requestAnimationFrame(() => {
            scrim.classList.add('is-visible')
        })

        document.body.classList.add('no-scroll')
        drawer.setAttribute('aria-hidden', 'false')
        hamburger?.setAttribute('aria-expanded', 'true')

        const firstFocusable = drawer.querySelector(FOCUSABLE_SELECTOR)
        if (firstFocusable) firstFocusable.focus()

        document.addEventListener('keydown', handleDrawerKeydown)
        scrim.addEventListener('click', closeDrawer, { once: true })
    }

    function closeDrawer() {
        drawer.classList.remove('is-open')
        scrim.classList.remove('is-visible')
        document.body.classList.remove('no-scroll')

        drawer.setAttribute('aria-hidden', 'true')
        hamburger?.setAttribute('aria-expanded', 'false')

        setTimeout(() => {
            scrim.hidden = true
        }, 200)

        document.removeEventListener('keydown', handleDrawerKeydown)

        if (lastFocusedElement) {
            lastFocusedElement.focus()
        }
    }

    function handleDrawerKeydown(event) {
        // Cerrar con ESC
        if (event.key === 'Escape') {
            event.preventDefault()
            closeDrawer()
            return
        }

        // Trampa de foco con TAB dentro del drawer
        if (event.key === 'Tab') {
            const focusable = [
                ...drawer.querySelectorAll(FOCUSABLE_SELECTOR),
            ]
            if (!focusable.length) return

            const first = focusable[0]
            const last = focusable[focusable.length - 1]

            if (event.shiftKey && document.activeElement === first) {
                event.preventDefault()
                last.focus()
            } else if (!event.shiftKey && document.activeElement === last) {
                event.preventDefault()
                first.focus()
            }
        }
    }

    // Click en el botón hamburguesa: abre/cierra
    hamburger?.addEventListener('click', () => {
        const isOpen = hamburger.getAttribute('aria-expanded') === 'true'
        isOpen ? closeDrawer() : openDrawer()
    })

    // Botón de cerrar dentro del drawer
    drawerClose?.addEventListener('click', closeDrawer)

    // Si haces click en un <a> dentro del drawer, se cierra
    drawer.addEventListener('click', (event) => {
        if (event.target.closest('a')) {
            closeDrawer()
        }
    })
})()

    // =========================================================
    // 2) App de tutoriales / videos (principal, shorts, historial, likes, subs)
    // =========================================================
    ; (() => {
        'use strict'

        // -------------------------------------------------------
        // Datos de videos (si no vienen de window.VIDEOS)
        // -------------------------------------------------------
        const hasWindowVideos =
            typeof window !== 'undefined' &&
            window.VIDEOS &&
            Object.keys(window.VIDEOS).length

        const windowVideos = hasWindowVideos ? Object.values(window.VIDEOS) : []

        const defaultVideos = hasWindowVideos
            ? []
            : [
                {
                    id: 'curso-js-basico',
                    title: 'Curso de JavaScript Básico — Desde Cero',
                    thumbnail: '../assets/img/Videos-Cursos/Thumbnail-1.jpg',
                    durationLabel: '12:48',
                    views: 128430,
                    publishedAt: '2025-08-18T10:00:00Z',
                    tags: ['Todos', 'JavaScript', 'Frontend', 'Principiantes'],
                    type: 'video',
                    channel: {
                        id: 'tecni-ni',
                        name: 'El Hacker',
                    },
                },
                {
                    id: 'curso-html-css',
                    title: 'HTML & CSS Moderno — Maquetación Responsive',
                    thumbnail: '../assets/img/Videos-Cursos/Thumbnail-2.jpg',
                    durationLabel: '08:20',
                    views: 80320,
                    publishedAt: '2025-07-01T09:00:00Z',
                    tags: ['Todos', 'HTML', 'CSS', 'Responsive'],
                    type: 'video',
                    channel: {
                        id: 'tecni-ni',
                        name: 'El Hacker',
                    },
                },
                {
                    id: 'tutorial-fetch-api',
                    title: 'Fetch API: consumir APIs con JavaScript',
                    thumbnail: '../assets/img/Videos-Cursos/Thumbnail-3.jpg',
                    durationLabel: '15:03',
                    views: 26510,
                    publishedAt: '2025-06-20T18:00:00Z',
                    tags: ['Todos', 'JavaScript', 'API', 'Async'],
                    type: 'video',
                    channel: {
                        id: 'tecni-ni',
                        name: 'El Hacker',
                    },
                },
                {
                    id: 'curso-js-avanzado',
                    title: 'JavaScript Avanzado — Patrones y Rendimiento',
                    thumbnail: '../assets/img/Videos-Cursos/Thumbnail-4.jpg',
                    durationLabel: '09:57',
                    views: 125600,
                    publishedAt: '2025-03-11T12:00:00Z',
                    tags: ['Todos', 'JavaScript', 'Avanzado'],
                    type: 'video',
                    channel: {
                        id: 'tecni-ni',
                        name: 'El Hacker',
                    },
                },
                {
                    id: 'curso-react',
                    title: 'React desde Cero — Hooks y Componentes',
                    thumbnail: '../assets/img/Videos-Cursos/Thumbnail-5.jpg',
                    durationLabel: '18:22',
                    views: 94210,
                    publishedAt: '2025-05-22T10:30:00Z',
                    tags: ['Todos', 'React', 'Frontend', 'SPA'],
                    type: 'video',
                    channel: {
                        id: 'tecni-ni',
                        name: 'El Hacker',
                    },
                },
                {
                    id: 'node-express-api',
                    title: 'Node.js + Express — API REST desde Cero',
                    thumbnail: '../assets/img/Videos-Cursos/Thumbnail-6.jpg',
                    durationLabel: '21:10',
                    views: 60580,
                    publishedAt: '2025-02-05T09:00:00Z',
                    tags: ['Todos', 'Node', 'Backend', 'API'],
                    type: 'video',
                    channel: {
                        id: 'tecni-ni',
                        name: 'El Hacker',
                    },
                },
                {
                    id: 'csharp-mvc-net7',
                    title: 'C# ASP.NET 7 — MVC por Capas',
                    thumbnail: '../assets/img/Videos-Cursos/Thumbnail-7.jpg',
                    durationLabel: '25:30',
                    views: 48890,
                    publishedAt: '2025-01-20T08:00:00Z',
                    tags: ['Todos', 'C#', 'Backend', 'MVC'],
                    type: 'video',
                    channel: {
                        id: 'tecni-ni',
                        name: 'El Hacker',
                    },
                },
                {
                    id: 'sql-basico',
                    title: 'SQL Básico — Consultas y Joins',
                    thumbnail: '../assets/img/Videos-Cursos/Thumbnail-8.jpg',
                    durationLabel: '13:40',
                    views: 71200,
                    publishedAt: '2024-12-10T10:00:00Z',
                    tags: ['Todos', 'SQL', 'BD'],
                    type: 'video',
                    channel: {
                        id: 'tecni-ni',
                        name: 'El Hacker',
                    },
                },
                {
                    id: 'git-github',
                    title: 'Git & GitHub — Flujo de Trabajo Profesional',
                    thumbnail: '../assets/img/Videos-Cursos/Thumbnail-9.jpg',
                    durationLabel: '11:05',
                    views: 55980,
                    publishedAt: '2025-04-05T12:00:00Z',
                    tags: ['Todos', 'Git', 'Colaboración'],
                    type: 'video',
                    channel: {
                        id: 'tecni-ni',
                        name: 'El Hacker',
                    },
                },
                {
                    id: 'docker-basico',
                    title: 'Docker Básico — Contenedores para Devs',
                    thumbnail: '../assets/img/Videos-Cursos/Thumbnail-10.jpg',
                    durationLabel: '14:12',
                    views: 48910,
                    publishedAt: '2025-03-02T17:00:00Z',
                    tags: ['Todos', 'Docker', 'DevOps'],
                    type: 'video',
                    channel: {
                        id: 'tecni-ni',
                        name: 'El Hacker',
                    },
                },

                // -------- Shorts / Reels --------
                {
                    id: 'short-1',
                    title: 'Truco rápido: map + filter en 60s',
                    thumbnail: '../assets/img/Videos-Cursos/Thumbnail-3.jpg',
                    durationLabel: '0:59',
                    views: 146000,
                    publishedAt: '2025-07-10T09:00:00Z',
                    tags: ['Todos', 'Shorts', 'JavaScript'],
                    type: 'short',
                    channel: {
                        id: 'tecni-ni',
                        name: 'El Hacker',
                    },
                    sources: [
                        {
                            src: '../assets/reels/short-1.mp4',
                            type: 'video/mp4',
                        },
                    ],
                },
                {
                    id: 'short-2',
                    title: 'Flexbox en 3 tips (Short)',
                    thumbnail: '../assets/img/Videos-Cursos/Thumbnail-2.jpg',
                    durationLabel: '0:39',
                    views: 98000,
                    publishedAt: '2025-08-02T10:00:00Z',
                    tags: ['Todos', 'Shorts', 'CSS'],
                    type: 'short',
                    channel: {
                        id: 'tecni-ni',
                        name: 'El Hacker',
                    },
                    sources: [
                        {
                            src: '../assets/reels/short-2.mp4',
                            type: 'video/mp4',
                        },
                    ],
                },
                {
                    id: 'short-3',
                    title: 'Async/Await explicado en 1 minuto',
                    thumbnail: '../assets/img/Videos-Cursos/Thumbnail-1.jpg',
                    durationLabel: '0:58',
                    views: 87500,
                    publishedAt: '2025-06-21T09:00:00Z',
                    tags: ['Todos', 'Shorts', 'JavaScript'],
                    type: 'short',
                    channel: {
                        id: 'tecni-ni',
                        name: 'El Hacker',
                    },
                    sources: [
                        {
                            src: '../assets/reels/short-3.mp4',
                            type: 'video/mp4',
                        },
                    ],
                },
                {
                    id: 'short-4',
                    title: 'Grid vs Flexbox: ¿cuándo usar cada uno?',
                    thumbnail: '../assets/img/Videos-Cursos/Thumbnail-4.jpg',
                    durationLabel: '0:54',
                    views: 102300,
                    publishedAt: '2025-07-28T09:00:00Z',
                    tags: ['Todos', 'Shorts', 'CSS'],
                    type: 'short',
                    channel: {
                        id: 'tecni-ni',
                        name: 'El Hacker',
                    },
                    sources: [
                        {
                            src: '../assets/reels/short-4.mp4',
                            type: 'video/mp4',
                        },
                    ],
                },
                {
                    id: 'short-5',
                    title: 'Atajo Git: stash en 60s',
                    thumbnail: '../assets/img/Videos-Cursos/Thumbnail-5.jpg',
                    durationLabel: '0:45',
                    views: 67000,
                    publishedAt: '2025-05-12T09:00:00Z',
                    tags: ['Todos', 'Shorts', 'Git'],
                    type: 'short',
                    channel: {
                        id: 'tecni-ni',
                        name: 'El Hacker',
                    },
                    sources: [
                        {
                            src: '../assets/reels/short-5.mp4',
                            type: 'video/mp4',
                        },
                    ],
                },
                {
                    id: 'short-6',
                    title: 'Tip rápido: consultas SQL JOIN',
                    thumbnail: '../assets/img/Videos-Cursos/Thumbnail-6.jpg',
                    durationLabel: '0:55',
                    views: 59000,
                    publishedAt: '2025-04-09T09:00:00Z',
                    tags: ['Todos', 'Shorts', 'SQL'],
                    type: 'short',
                    channel: {
                        id: 'tecni-ni',
                        name: 'El Hacker',
                    },
                    sources: [
                        {
                            src: '../assets/reels/short-6.mp4',
                            type: 'video/mp4',
                        },
                    ],
                },
                {
                    id: 'short-7',
                    title: 'Hooks de React en 1 minuto',
                    thumbnail: '../assets/img/Videos-Cursos/Thumbnail-7.jpg',
                    durationLabel: '0:57',
                    views: 143200,
                    publishedAt: '2025-07-02T09:00:00Z',
                    tags: ['Todos', 'Shorts', 'React'],
                    type: 'short',
                    channel: {
                        id: 'tecni-ni',
                        name: 'El Hacker',
                    },
                    sources: [
                        {
                            src: '../assets/reels/short-7.mp4',
                            type: 'video/mp4',
                        },
                    ],
                },
                {
                    id: 'short-8',
                    title: 'Node.js Express: middleware esencial',
                    thumbnail: '../assets/img/Videos-Cursos/Thumbnail-8.jpg',
                    durationLabel: '0:49',
                    views: 81200,
                    publishedAt: '2025-06-13T09:00:00Z',
                    tags: ['Todos', 'Shorts', 'Node'],
                    type: 'short',
                    channel: {
                        id: 'tecni-ni',
                        name: 'El Hacker',
                    },
                    sources: [
                        {
                            src: '../assets/reels/short-8.mp4',
                            type: 'video/mp4',
                        },
                    ],
                },
                {
                    id: 'short-9',
                    title: 'Docker build en 60s',
                    thumbnail: '../assets/img/Videos-Cursos/Thumbnail-9.jpg',
                    durationLabel: '0:51',
                    views: 73200,
                    publishedAt: '2025-03-30T09:00:00Z',
                    tags: ['Todos', 'Shorts', 'Docker'],
                    type: 'short',
                    channel: {
                        id: 'tecni-ni',
                        name: 'El Hacker',
                    },
                    sources: [
                        {
                            src: '../assets/reels/short-9.mp4',
                            type: 'video/mp4',
                        },
                    ],
                },
                {
                    id: 'short-10',
                    title: 'C# LINQ: query rápida',
                    thumbnail: '../assets/img/Videos-Cursos/Thumbnail-10.jpg',
                    durationLabel: '0:56',
                    views: 45600,
                    publishedAt: '2025-05-19T09:00:00Z',
                    tags: ['Todos', 'Shorts', 'C#'],
                    type: 'short',
                    channel: {
                        id: 'tecni-ni',
                        name: 'El Hacker',
                    },
                    sources: [
                        {
                            src: '../assets/reels/short-10.mp4',
                            type: 'video/mp4',
                        },
                    ],
                },
                {
                    id: 'short-11',
                    title: 'Patrón Observer explicado en 1 min',
                    thumbnail: '../assets/img/Videos-Cursos/Thumbnail-1.jpg',
                    durationLabel: '0:53',
                    views: 98500,
                    publishedAt: '2025-06-07T09:00:00Z',
                    tags: ['Todos', 'Shorts', 'JavaScript'],
                    type: 'short',
                    channel: {
                        id: 'tecni-ni',
                        name: 'El Hacker',
                    },
                    sources: [
                        {
                            src: '../assets/reels/short-11.mp4',
                            type: 'video/mp4',
                        },
                    ],
                },
                {
                    id: 'short-12',
                    title: 'CSS Variables en 60s',
                    thumbnail: '../assets/img/Videos-Cursos/Thumbnail-2.jpg',
                    durationLabel: '0:41',
                    views: 55200,
                    publishedAt: '2025-04-25T09:00:00Z',
                    tags: ['Todos', 'Shorts', 'CSS'],
                    type: 'short',
                    channel: {
                        id: 'tecni-ni',
                        name: 'El Hacker',
                    },
                    sources: [
                        {
                            src: '../assets/reels/short-12.mp4',
                            type: 'video/mp4',
                        },
                    ],
                },
                {
                    id: 'short-13',
                    title: 'API REST: diferencias GET vs POST',
                    thumbnail: '../assets/img/Videos-Cursos/Thumbnail-3.jpg',
                    durationLabel: '0:59',
                    views: 123900,
                    publishedAt: '2025-08-11T09:00:00Z',
                    tags: ['Todos', 'Shorts', 'API'],
                    type: 'short',
                    channel: {
                        id: 'tecni-ni',
                        name: 'El Hacker',
                    },
                    sources: [
                        {
                            src: '../assets/reels/short-13.mp4',
                            type: 'video/mp4',
                        },
                    ],
                },
                {
                    id: 'short-14',
                    title: 'TypeScript: tipado en 1 min',
                    thumbnail: '../assets/img/Videos-Cursos/Thumbnail-4.jpg',
                    durationLabel: '0:48',
                    views: 67800,
                    publishedAt: '2025-06-16T09:00:00Z',
                    tags: ['Todos', 'Shorts', 'TypeScript'],
                    type: 'short',
                    channel: {
                        id: 'tecni-ni',
                        name: 'El Hacker',
                    },
                    sources: [
                        {
                            src: '../assets/reels/short-14.mp4',
                            type: 'video/mp4',
                        },
                    ],
                },
                {
                    id: 'short-15',
                    title: 'UI/UX: microinteracciones rápidas',
                    thumbnail: '../assets/img/Videos-Cursos/Thumbnail-5.jpg',
                    durationLabel: '0:42',
                    views: 82000,
                    publishedAt: '2025-07-22T09:00:00Z',
                    tags: ['Todos', 'Shorts', 'UI/UX'],
                    type: 'short',
                    channel: {
                        id: 'tecni-ni',
                        name: 'El Hacker',
                    },
                    sources: [
                        {
                            src: '../assets/reels/short-15.mp4',
                            type: 'video/mp4',
                        },
                    ],
                },
                {
                    id: 'short-16',
                    title: 'Testing con Jest en 1 minuto',
                    thumbnail: '../assets/img/Videos-Cursos/Thumbnail-6.jpg',
                    durationLabel: '0:55',
                    views: 69400,
                    publishedAt: '2025-07-30T09:00:00Z',
                    tags: ['Todos', 'Shorts', 'Testing'],
                    type: 'short',
                    channel: {
                        id: 'tecni-ni',
                        name: 'El Hacker',
                    },
                    sources: [
                        {
                            src: '../assets/reels/short-16.mp4',
                            type: 'video/mp4',
                        },
                    ],
                },
            ]

        const allVideos = (hasWindowVideos ? windowVideos : defaultVideos).map(
            (video) => ({
                ...video,
                channel: video.channel || {
                    id: 'tecni-ni',
                    name: 'El Hacker',
                },
            })
        )

        // -------------------------------------------------------
        // Helpers generales
        // -------------------------------------------------------
        const $ = (selector, root = document) => root.querySelector(selector)
        const $$ = (selector, root = document) =>
            Array.from(root.querySelectorAll(selector))

        const numberFormatter = new Intl.NumberFormat('es-ES')

        const escapeHtml = (value) =>
            String(value || '')
                .replace(/&/g, '&amp;')
                .replace(/</g, '&lt;')
                .replace(/>/g, '&gt;')

        function formatRelativeDate(dateInput) {
            const date = new Date(dateInput)
            const now = new Date()
            const diffSeconds = Math.floor((now - date) / 1000)
            const minutes = Math.floor(diffSeconds / 60)
            const hours = Math.floor(minutes / 60)
            const days = Math.floor(hours / 24)
            const months = Math.floor(days / 30)
            const years = Math.floor(months / 12)

            if (years > 0) {
                return years === 1 ? 'hace 1 año' : `hace ${years} años`
            }
            if (months > 0) {
                return months === 1 ? 'hace 1 mes' : `hace ${months} meses`
            }
            if (days > 0) {
                return days === 1 ? 'hace 1 día' : `hace ${days} días`
            }
            if (hours > 0) {
                return hours === 1 ? 'hace 1 hora' : `hace ${hours} horas`
            }
            if (minutes > 0) {
                return minutes === 1 ? 'hace 1 minuto' : `hace ${minutes} minutos`
            }
            return 'hoy'
        }

        // -------------------------------------------------------
        // Acceso a definiciones de videos
        // -------------------------------------------------------
        function getVideoDef(id) {
            if (window.VIDEOS && window.VIDEOS[id]) {
                return window.VIDEOS[id]
            }
            const video = allVideos.find((v) => v.id === id)
            if (!video) {
                throw new Error('[getVideoDef] No existe id: ' + id)
            }
            return video
        }

        // -------------------------------------------------------
        // IndexedDB: history, likes, subs
        // -------------------------------------------------------
        function openDb() {
            return new Promise((resolve, reject) => {
                const request = indexedDB.open('conecta2', 2)

                request.onupgradeneeded = () => {
                    const db = request.result

                    // Historial
                    if (!db.objectStoreNames.contains('history')) {
                        const store = db.createObjectStore('history', {
                            keyPath: 'id',
                            autoIncrement: true,
                        })
                        store.createIndex('by_ts', 'ts', { unique: false })
                        store.createIndex('by_type', 'type', { unique: false })
                    }

                    // Likes
                    if (!db.objectStoreNames.contains('likes')) {
                        const likesStore = db.createObjectStore('likes', {
                            keyPath: 'videoId',
                        })
                        likesStore.createIndex('by_ts', 'ts', { unique: false })
                    } else {
                        // Asegurar index by_ts
                        try {
                            db.transaction('likes', 'readonly')
                                .objectStore('likes')
                                .index('by_ts')
                        } catch {
                            const likesStore = db.transaction.objectStore('likes')
                            likesStore.createIndex('by_ts', 'ts', { unique: false })
                        }
                    }

                    // Subs
                    if (!db.objectStoreNames.contains('subs')) {
                        db.createObjectStore('subs', { keyPath: 'channelId' })
                    }
                }

                request.onsuccess = () => resolve(request.result)
                request.onerror = () => reject(request.error)
            })
        }

        async function withStore(storeName, mode, fn) {
            const db = await openDb()
            return new Promise((resolve, reject) => {
                const tx = db.transaction(storeName, mode)
                const store = tx.objectStore(storeName)
                const request = fn(store)

                tx.oncomplete = () => resolve(request && request.result)
                tx.onerror = () => reject(tx.error)
            })
        }

        // Historial: añadir entrada
        async function addHistoryEntry(entry) {
            await withStore('history', 'readwrite', (store) =>
                store.add({
                    ...entry,
                    ts: Date.now(),
                })
            )
        }

        // Historial: obtener todo (ordenado por ts DESC)
        async function getHistoryEntries() {
            return new Promise(async (resolve, reject) => {
                const db = await openDb()
                const tx = db.transaction('history', 'readonly')
                const index = tx.objectStore('history').index('by_ts')
                const items = []

                index.openCursor(null, 'prev').onsuccess = (event) => {
                    const cursor = event.target.result
                    if (cursor) {
                        items.push(cursor.value)
                        cursor.continue()
                    } else {
                        resolve(items)
                    }
                }

                tx.onerror = () => reject(tx.error)
            })
        }

        // Likes: toggle
        async function toggleLike(videoId) {
            return withStore('likes', 'readwrite', (store) => {
                const getReq = store.get(videoId)
                getReq.onsuccess = () => {
                    if (getReq.result) {
                        store.delete(videoId)
                    } else {
                        store.put({
                            videoId,
                            ts: Date.now(),
                        })
                    }
                }
            })
        }

        // Likes: obtener conjunto de ids
        async function getLikesSet() {
            return new Promise(async (resolve, reject) => {
                const db = await openDb()
                const tx = db.transaction('likes', 'readonly')
                const store = tx.objectStore('likes')
                const set = new Set()

                store.openCursor().onsuccess = (event) => {
                    const cursor = event.target.result
                    if (cursor) {
                        set.add(cursor.value.videoId)
                        cursor.continue()
                    } else {
                        resolve(set)
                    }
                }

                tx.onerror = () => reject(tx.error)
            })
        }

        // Likes: historial ordenado por ts DESC
        async function getLikesHistory() {
            return new Promise(async (resolve, reject) => {
                const db = await openDb()
                const tx = db.transaction('likes', 'readonly')
                const index = tx.objectStore('likes').index('by_ts')
                const items = []

                index.openCursor(null, 'prev').onsuccess = (event) => {
                    const cursor = event.target.result
                    if (cursor) {
                        items.push(cursor.value)
                        cursor.continue()
                    } else {
                        resolve(items)
                    }
                }

                tx.onerror = () => reject(tx.error)
            })
        }

        // Subs: toggle
        async function toggleSubscription(channelId, name) {
            return withStore('subs', 'readwrite', (store) => {
                const getReq = store.get(channelId)
                getReq.onsuccess = () => {
                    if (getReq.result) {
                        store.delete(channelId)
                    } else {
                        store.put({ channelId, name })
                    }
                }
            })
        }

        // Subs: obtener conjunto de ids
        async function getSubscriptionsSet() {
            return new Promise(async (resolve, reject) => {
                const db = await openDb()
                const tx = db.transaction('subs', 'readonly')
                const store = tx.objectStore('subs')
                const set = new Set()

                store.openCursor().onsuccess = (event) => {
                    const cursor = event.target.result
                    if (cursor) {
                        set.add(cursor.value.channelId)
                        cursor.continue()
                    } else {
                        resolve(set)
                    }
                }

                tx.onerror = () => reject(tx.error)
            })
        }

        // -------------------------------------------------------
        // Estado de la app
        // -------------------------------------------------------
        let state = {
            q: '',
            tag: 'Todos',
            view: 'principal', // principal | shorts | subs | history | likes
            page: 0,
            pageSize: 12,
            filtered: [],
            loading: false,
            done: false,
            likes: new Set(),
            subs: new Set(),
        }

        // -------------------------------------------------------
        // Helpers de UI
        // -------------------------------------------------------
        function showElement(el) {
            if (!el) return
            el.hidden = false
            el.removeAttribute('hidden')
        }

        function hideElement(el) {
            if (!el) return
            el.hidden = true
        }

        function setLeftNavActive(action) {
            $$('.tut-left [data-action]').forEach((item) => {
                if (item.getAttribute('data-action') === action) {
                    item.classList.add('is-active')
                } else {
                    item.classList.remove('is-active')
                }
            })
        }

        // -------------------------------------------------------
        // Render de layout principal (ya viene del .cshtml)
        // -------------------------------------------------------
        function initTutorialApp() {
            const app = $('#app')
            if (!app) return

            // El HTML ya está en la vista
            app.classList.add('tut-app')

            // Drawer lateral móvil
            $('#tutBurger')?.addEventListener('click', openLeftDrawer)
            $('#tutBackdrop')?.addEventListener('click', closeLeftDrawer)

            $('#tutLeft')?.addEventListener('click', (event) => {
                const item = event.target.closest('[data-action]')
                if (!item) return

                event.preventDefault()
                state.view = item.getAttribute('data-action')
                setLeftNavActive(state.view)
                closeLeftDrawer()
                setupViewForCurrentState()
            })

            // Chips / filtros
            renderChips()

            // Búsqueda
            const searchInput = $('#tutSearch')
            const searchBtn = $('#tutSearchBtn')

            const applySearch = () => {
                state.q = (searchInput?.value || '').trim().toLowerCase()
                refreshViewContent()
            }

            searchInput?.addEventListener('input', applySearch)
            searchInput?.addEventListener('keydown', (event) => {
                if (event.key === 'Enter') {
                    applySearch()
                }
            })
            searchBtn?.addEventListener('click', applySearch)

            // Scroll horizontal de chips
            const chipsEl = $('#tutChips')
            if (chipsEl) {
                chipsEl.addEventListener(
                    'wheel',
                    (event) => {
                        if (Math.abs(event.deltaY) > Math.abs(event.deltaX)) {
                            event.preventDefault()
                            chipsEl.scrollLeft += event.deltaY
                        }
                    },
                    { passive: false }
                )
            }

            // Vista inicial
            state.view = 'principal'
            setLeftNavActive('principal')
            setupViewForCurrentState()

            // Cargar likes/subs desde IndexedDB y luego refrescar contenido
            Promise.all([getLikesSet(), getSubscriptionsSet()])
                .then(([likesSet, subsSet]) => {
                    state.likes = likesSet
                    state.subs = subsSet
                })
                .catch(() => { })
                .finally(() => {
                    refreshViewContent()
                })
        }

        function openLeftDrawer() {
            document.body.classList.add('tut-no-scroll')
            $('#tutLeft')?.classList.add('is-open')
            const bd = $('#tutBackdrop')
            if (bd) bd.hidden = false
        }

        function closeLeftDrawer() {
            document.body.classList.remove('tut-no-scroll')
            $('#tutLeft')?.classList.remove('is-open')
            const bd = $('#tutBackdrop')
            if (bd) bd.hidden = true
        }

        // -------------------------------------------------------
        // Chips de categorías
        // -------------------------------------------------------
        function renderChips() {
            const tagsSet = new Set(['Todos', 'Shorts'])

            allVideos.forEach((video) =>
                (video.tags || []).forEach((tag) => tagsSet.add(tag))
            )

            const baseTags = Array.from(tagsSet).concat([
                'Frontend',
                'Backend',
                'DevOps',
                'React',
                'Node',
                'CSS',
                'HTML',
                'Async',
                'API',
                'SPA',
                'MVC',
                'SQL',
                'Git',
                'Testing',
                'UI/UX',
                'TypeScript',
            ])

            const chipsContainer = $('#tutChips')
            if (!chipsContainer) return

            chipsContainer.innerHTML = baseTags
                .map(
                    (tag) => `
          <button
            class="tut-chip${tag === state.tag ? ' is-active' : ''}"
            data-tag="${escapeHtml(tag)}"
          >
            ${escapeHtml(tag)}
          </button>
        `
                )
                .join('')

            chipsContainer.addEventListener('click', (event) => {
                const chip = event.target.closest('.tut-chip')
                if (!chip) return

                state.tag = chip.dataset.tag

                $$('.tut-chip', chipsContainer).forEach((c) =>
                    c.classList.remove('is-active')
                )
                chip.classList.add('is-active')

                refreshViewContent()
            })
        }

        // -------------------------------------------------------
        // Cambio de vista (principal, shorts, subs, history, likes)
        // -------------------------------------------------------
        async function setupViewForCurrentState() {
            const reelsSection = $('#tutReels')
            const resultsWrap = $('.tut-results')
            const listSection = $('#tutList')

            if (state.view === 'history' || state.view === 'likes') {
                hideElement(reelsSection)
                hideElement(resultsWrap)
                showElement(listSection)
                await renderHistoryOrLikesList()
                return
            }

            if (state.view === 'subs') {
                hideElement(reelsSection)
                showElement(resultsWrap)
                hideElement(listSection)
                await resetAndRenderGrid()
                setupInfiniteScroll()
                return
            }

            if (state.view === 'shorts') {
                showElement(reelsSection)
                hideElement(resultsWrap)
                hideElement(listSection)
                renderReels()
                return
            }

            // principal
            showElement(reelsSection)
            showElement(resultsWrap)
            hideElement(listSection)
            renderReels()
            await resetAndRenderGrid()
            setupInfiniteScroll()
        }

        function refreshViewContent() {
            const reelsSection = $('#tutReels')
            const resultsWrap = $('.tut-results')
            const listSection = $('#tutList')

            if (state.view === 'history' || state.view === 'likes') {
                hideElement(reelsSection)
                hideElement(resultsWrap)
                showElement(listSection)
                renderHistoryOrLikesList()
                return
            }

            if (state.view === 'subs') {
                hideElement(reelsSection)
                showElement(resultsWrap)
                hideElement(listSection)
                resetAndRenderGrid()
                return
            }

            if (state.view === 'shorts') {
                showElement(reelsSection)
                hideElement(resultsWrap)
                hideElement(listSection)
                renderReels()
                return
            }

            // principal
            showElement(reelsSection)
            showElement(resultsWrap)
            hideElement(listSection)
            resetAndRenderGrid()
            renderReels()
        }

        // -------------------------------------------------------
        // Helpers para videos/shorts
        // -------------------------------------------------------
        function getShorts() {
            return allVideos.filter((video) => video.type === 'short')
        }

        function getFullVideos() {
            return allVideos.filter((video) => video.type === 'video')
        }

        // -------------------------------------------------------
        // Reels / shorts
        // -------------------------------------------------------
        function renderReels() {
            const reelsSection = $('#tutReels')
            if (!reelsSection) return

            const shorts = getShorts()
            const repeatedList = []

            for (let i = 0; i < Math.max(30, shorts.length); i++) {
                repeatedList.push(shorts[i % Math.max(1, shorts.length)])
            }

            if (state.view === 'shorts') {
                reelsSection.classList.add('tut-reels--spaced')
                reelsSection.innerHTML = `
        <div class="tut-reels__title">Shorts</div>
        <div class="tut-reels__grid" id="tutReelsGrid">
          ${shorts.map(renderReelItem).join('')}
        </div>
      `
            } else {
                reelsSection.classList.add('tut-reels--spaced')
                reelsSection.innerHTML = `
        <div class="tut-reels__title">Reels</div>
        <div class="tut-reels__strip hscroll" id="tutReelsStrip">
          ${repeatedList.map(renderReelItem).join('')}
        </div>
      `
                const strip = $('#tutReelsStrip')
                strip?.addEventListener(
                    'wheel',
                    (event) => {
                        if (Math.abs(event.deltaY) > Math.abs(event.deltaX)) {
                            event.preventDefault()
                            strip.scrollLeft += event.deltaY
                        }
                    },
                    { passive: false }
                )
            }

            reelsSection.querySelectorAll('.tut-reel').forEach((reelEl) => {
                reelEl.addEventListener('click', async (event) => {
                    event.preventDefault()
                    const reelId = reelEl.getAttribute('data-reel-id')
                    openReelModal(reelId)
                    await addHistoryEntry({
                        type: 'short',
                        videoId: reelId,
                    })
                })
            })
        }

        function renderReelItem(video) {
            return `
      <a
        class="tut-reel${state.view === 'shorts' ? ' tut-reel--grid' : ''}"
        href="#"
        data-reel-id="${escapeHtml(video.id)}"
        aria-label="${escapeHtml(video.title)}"
      >
        <div class="tut-reel__thumb">
          <img
            src="${video.thumbnail}"
            alt="${escapeHtml(video.title)}"
            loading="lazy"
          />
          <span class="tut-duration">${escapeHtml(video.durationLabel || '')}</span>
        </div>
        <div class="tut-reel__title">${escapeHtml(video.title)}</div>
      </a>
    `
        }

        // -------------------------------------------------------
        // Filtro (búsqueda + tags)
        // -------------------------------------------------------
        function filterVideos(list) {
            let filtered = list
            const query = state.q
            const tag = state.tag

            if (query) {
                const qLower = query.toLowerCase()
                filtered = filtered.filter((video) =>
                    (
                        (video.title || '') +
                        ' ' +
                        (video.channel?.name || '') +
                        ' ' +
                        (video.tags || []).join(' ')
                    )
                        .toLowerCase()
                        .includes(qLower)
                )
            }

            if (tag && tag !== 'Todos') {
                if (tag === 'Shorts') {
                    filtered = filtered.filter((video) => video.type === 'short')
                } else {
                    filtered = filtered.filter((video) =>
                        (video.tags || []).includes(tag)
                    )
                }
            }

            return filtered
        }

        async function getVideosForCurrentView() {
            const videos = getFullVideos()

            if (state.view === 'subs') {
                const subsSet = state.subs
                return videos.filter((video) => subsSet.has(video.channel.id))
            }

            return videos
        }

        // -------------------------------------------------------
        // Grid de resultados + scroll infinito
        // -------------------------------------------------------
        async function resetAndRenderGrid() {
            if (state.view === 'shorts') {
                const g = $('#tutGrid')
                if (g) g.innerHTML = ''
                return
            }

            state.page = 0
            state.done = false
            state.loading = false

            const baseList = await getVideosForCurrentView()
            state.filtered = filterVideos(baseList)

            const grid = $('#tutGrid')
            if (!grid) return

            grid.innerHTML = ''

            if (!state.filtered.length) {
                grid.innerHTML = '<div class="tut-empty">No hay resultados.</div>'
                state.done = true
                return
            }

            loadNextPage()
        }

        function loadNextPage() {
            if (state.loading || state.done) return

            state.loading = true

            const start = state.page * state.pageSize
            const end = start + state.pageSize
            const slice = state.filtered.slice(start, end)

            if (!slice.length) {
                state.done = true
                state.loading = false
                return
            }

            const grid = $('#tutGrid')
            if (!grid) return

            const fragment = document.createDocumentFragment()
            slice.forEach((video) => fragment.appendChild(createVideoCard(video)))
            grid.appendChild(fragment)

            state.page++
            state.loading = false

            if (end >= state.filtered.length) {
                state.done = true
            }
        }

        function setupInfiniteScroll() {
            const sentinel = $('#tutSentinel')
            if (!sentinel) return

            if (setupInfiniteScroll._io) {
                setupInfiniteScroll._io.disconnect()
            }

            const io = new IntersectionObserver(
                (entries) => {
                    entries.forEach((entry) => {
                        if (entry.isIntersecting) {
                            loadNextPage()
                        }
                    })
                },
                {
                    root: null,
                    rootMargin: '600px 0px',
                    threshold: 0,
                }
            )

            io.observe(sentinel)
            setupInfiniteScroll._io = io
        }

        // -------------------------------------------------------
        // Tarjeta de video (grid)
        // -------------------------------------------------------
        function createVideoCard(video) {
            const card = document.createElement('a')
            card.className = 'tut-card'
            card.href = 'video.html#' + encodeURIComponent(video.id)

            card.addEventListener(
                'click',
                async () => {
                    sessionStorage.setItem('videoId', video.id)
                    sessionStorage.setItem('videoTitle', video.title || '')
                    await addHistoryEntry({
                        type: 'video',
                        videoId: video.id,
                    })
                },
                { capture: true }
            )

            const isLiked = state.likes.has(video.id)
            const isSubbed = state.subs.has(video.channel.id)

            card.innerHTML = `
      <div class="tut-thumb">
        <img
          src="${video.thumbnail}"
          alt="${escapeHtml(video.title)}"
          loading="lazy"
        >
        <span class="tut-duration">${escapeHtml(video.durationLabel || '')}</span>
        <button class="tut-more" aria-label="Más acciones">⋮</button>
        <button class="tut-like" aria-pressed="${isLiked ? 'true' : 'false'}" title="Me gusta">
          ${isLiked ? '❤' : '♡'}
        </button>
      </div>
      <div class="tut-body">
        <div class="tut-avatar" aria-hidden="true"></div>
        <div class="tut-texts">
          <div class="tut-title">${escapeHtml(video.title)}</div>
          <div class="tut-meta">
            ${escapeHtml(video.channel?.name || '')} ·
            ${numberFormatter.format(video.views)} vistas ·
            ${formatRelativeDate(video.publishedAt)}
            <button
              class="tut-sub"
              aria-pressed="${isSubbed ? 'true' : 'false'}"
              title="Suscribirse"
            >
              ${isSubbed ? '★ Suscrito' : '☆ Suscribirse'}
            </button>
          </div>
        </div>
      </div>
    `

            // Botón "más acciones"
            card.querySelector('.tut-more').addEventListener('click', (event) => {
                event.preventDefault()
                event.stopPropagation()
                alert('Más acciones (demo)')
            })

            // Like
            card.querySelector('.tut-like').addEventListener('click', async (event) => {
                event.preventDefault()
                event.stopPropagation()

                await toggleLike(video.id)
                state.likes = await getLikesSet()

                const btn = event.currentTarget
                const likedNow = state.likes.has(video.id)
                btn.setAttribute('aria-pressed', likedNow ? 'true' : 'false')
                btn.textContent = likedNow ? '❤' : '♡'
            })

            // Suscripción
            card.querySelector('.tut-sub').addEventListener('click', async (event) => {
                event.preventDefault()
                event.stopPropagation()

                await toggleSubscription(video.channel.id, video.channel.name)
                state.subs = await getSubscriptionsSet()

                const btn = event.currentTarget
                const subbedNow = state.subs.has(video.channel.id)
                btn.setAttribute('aria-pressed', subbedNow ? 'true' : 'false')
                btn.textContent = subbedNow ? '★ Suscrito' : '☆ Suscribirse'
            })

            return card
        }

        // -------------------------------------------------------
        // Historial / Likes: lista en modo "tlist"
        // -------------------------------------------------------
        async function renderHistoryOrLikesList() {
            const container = $('#tutList')
            if (!container) return

            container.innerHTML = ''

            const showEmpty = () => {
                container.innerHTML = '<div class="tut-empty">No hay resultados.</div>'
            }

            if (state.view === 'history') {
                const history = await getHistoryEntries()
                const mapped = (history || [])
                    .filter((entry) => entry.type === 'video')
                    .map((entry) => ({
                        ts: entry.ts,
                        v: getVideoDef(entry.videoId),
                    }))
                    .filter((item) => !!item.v)

                if (!mapped.length) {
                    showEmpty()
                    return
                }

                container.append(
                    ...mapped.map(({ ts, v }) =>
                        createListItem(v, {
                            badge:
                                'Visto ' +
                                formatRelativeDate(ts) +
                                ' • ' +
                                new Date(ts).toLocaleString(),
                        })
                    )
                )
                return
            }

            if (state.view === 'likes') {
                const likesHistory = await getLikesHistory()
                const mapped = (likesHistory || [])
                    .map((entry) => ({
                        ts: entry.ts,
                        v: getVideoDef(entry.videoId),
                    }))
                    .filter((item) => !!item.v)

                if (!mapped.length) {
                    showEmpty()
                    return
                }

                container.append(
                    ...mapped.map(({ ts, v }) =>
                        createListItem(v, {
                            badge:
                                'Like ' +
                                formatRelativeDate(ts) +
                                ' • ' +
                                new Date(ts).toLocaleString(),
                        })
                    )
                )
                return
            }

            showEmpty()
        }

        function createListItem(video, { badge } = {}) {
            const link = document.createElement('a')
            link.className = 'tlist-item'
            link.href = 'video.html#' + encodeURIComponent(video.id)

            link.addEventListener(
                'click',
                async () => {
                    sessionStorage.setItem('videoId', video.id)
                    sessionStorage.setItem('videoTitle', video.title || '')
                    await addHistoryEntry({
                        type: 'video',
                        videoId: video.id,
                    })
                },
                { capture: true }
            )

            link.innerHTML = `
      <div class="tlist-thumb">
        <img src="${video.thumbnail}" alt="${escapeHtml(video.title)}">
        <span class="tut-duration">${escapeHtml(video.durationLabel || '')}</span>
      </div>
      <div class="tlist-body">
        <div class="tlist-title">${escapeHtml(video.title)}</div>
        <div class="tlist-meta">
          ${escapeHtml(video.channel?.name || '')} ·
          ${numberFormatter.format(video.views)} vistas ·
          ${formatRelativeDate(video.publishedAt)}
        </div>
        ${badge
                    ? `<div class="tlist-badge">${escapeHtml(badge)}</div>`
                    : ''
                }
      </div>
    `

            return link
        }

        // -------------------------------------------------------
        // Modal de reels (shorts)
        // -------------------------------------------------------
        function openReelModal(reelId) {
            const def = getVideoDef(reelId)
            const sources = def.sources

            if (!Array.isArray(sources) || sources.length === 0) {
                throw new Error(
                    '[openReelModal] Reel ' + reelId + " no trae 'sources'. Corrige los datos."
                )
            }

            const poster = def.thumbnail || ''
            const title = def.title || reelId

            const modal = document.createElement('div')
            modal.className = 'tut-modal'
            modal.setAttribute('role', 'dialog')
            modal.setAttribute('aria-label', 'Reel: ' + title)

            modal.innerHTML = `
      <div class="tut-modal__box">
        <button class="tut-modal__close" aria-label="Cerrar">✕</button>
        <div class="tut-modal__wrap-9x16">
          <video
            class="tut-modal__video"
            playsinline
            webkit-playsinline
            controls
            preload="metadata"
            poster="${escapeHtml(poster)}"
          ></video>
        </div>
      </div>
    `

            const videoEl = modal.querySelector('.tut-modal__video')

            sources.forEach((srcDef) => {
                const sourceEl = document.createElement('source')
                sourceEl.src = srcDef.src
                sourceEl.type = srcDef.type || 'video/mp4'
                videoEl.appendChild(sourceEl)
            })

            videoEl.muted = true
            videoEl.play().catch(() => { })

            const closeModal = () => {
                try {
                    videoEl.pause()
                } catch { }
                document.body.classList.remove('tut-no-scroll')
                document.removeEventListener('keydown', handleKeyDown)
                modal.remove()
            }

            const handleKeyDown = (event) => {
                if (event.key === 'Escape') {
                    closeModal()
                }
            }

            modal.addEventListener('click', (event) => {
                if (event.target === modal) {
                    closeModal()
                }
            })

            modal.querySelector('.tut-modal__close').addEventListener('click', closeModal)

            document.addEventListener('keydown', handleKeyDown, { passive: true })
            document.body.appendChild(modal)
            document.body.classList.add('tut-no-scroll')
        }

        // Iniciar app al cargar DOM
        document.addEventListener('DOMContentLoaded', initTutorialApp)
    })()

    // =========================================================
    // 3) Pantalla de carga / loading-screen
    // =========================================================
    ; (() => {
        const loadingScreen = document.getElementById('loading-screen')
        if (!loadingScreen) return

        const circle = loadingScreen.querySelector('.thermo-fill')
        const percentText = loadingScreen.querySelector('#thermoPercent')

        const radius = 52
        const circumference = 2 * Math.PI * radius

        circle.style.strokeDasharray = String(circumference)
        circle.style.strokeDashoffset = String(circumference)

        let currentValue = 0
        let targetValue = 92
        let isDone = false
        let rafId = null

        const clamp = (value, min, max) => Math.min(max, Math.max(min, value))

        const setProgress = (value) => {
            const v = clamp(Math.round(value), 0, 100)
            circle.style.strokeDashoffset = String(circumference * (1 - v / 100))
            percentText.textContent = v + '%'
        }

        const animate = () => {
            currentValue += (targetValue - currentValue) * 0.08
            setProgress(currentValue)

            if (isDone && currentValue >= 99.5) {
                setProgress(100)
                loadingScreen.classList.add('is-done')
                cancelAnimationFrame(rafId)
                return
            }

            rafId = requestAnimationFrame(animate)
        }

        rafId = requestAnimationFrame(animate)

        window.addEventListener('load', () => {
            isDone = true
            targetValue = 100
            if (currentValue < 70) {
                currentValue = 70
            }
            setTimeout(() => {
                targetValue = 100
            }, 80)
        })

        // Por si load tarda demasiado, forzamos finalización
        setTimeout(() => {
            if (!isDone) {
                isDone = true
                targetValue = 100
            }
        }, 8000)
    })()