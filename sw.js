const CACHE_NAME = 'maximahome-v1';
const BASE_URL = '/MaximaHome';
const urlsToCache = [
  `${BASE_URL}/`,
  `${BASE_URL}/index.html`,
  `${BASE_URL}/css/style.css`,
  `${BASE_URL}/css/icon-animations.css`,
  `${BASE_URL}/css/projects.css`,
  `${BASE_URL}/js/main.js`,
  `${BASE_URL}/images/logo.png`,
  `${BASE_URL}/images/icon-192x192.png`,
  `${BASE_URL}/images/icon-512x512.png`,
  `${BASE_URL}/images/splash.png`,
  `${BASE_URL}/images/بنر سایت.png`,
  `${BASE_URL}/images/image5.png`,
  `${BASE_URL}/images/88.png`,
  `${BASE_URL}/images/08.png`,
  `${BASE_URL}/images/22.png`,
  `${BASE_URL}/images/33.png`,
  `${BASE_URL}/images/44.png`,
  `${BASE_URL}/images/01.png`,
  `${BASE_URL}/images/new1.png`,
  `${BASE_URL}/Video/film1.mp4`,
  `${BASE_URL}/Video/film2.mp4`,
  `${BASE_URL}/Video/film3.mp4`
];

self.addEventListener('install', function(event) {
  event.waitUntil(
    caches.open(CACHE_NAME)
      .then(function(cache) {
        console.log('Opened cache');
        return cache.addAll(urlsToCache);
      })
  );
});

self.addEventListener('fetch', function(event) {
  event.respondWith(
    caches.match(event.request)
      .then(function(response) {
        if (response) {
          return response;
        }
        return fetch(event.request)
          .then(function(response) {
            if(!response || response.status !== 200 || response.type !== 'basic') {
              return response;
            }
            var responseToCache = response.clone();
            caches.open(CACHE_NAME)
              .then(function(cache) {
                cache.put(event.request, responseToCache);
              });
            return response;
          });
      })
  );
});

self.addEventListener('activate', function(event) {
  event.waitUntil(
    caches.keys().then(function(cacheNames) {
      return Promise.all(
        cacheNames.map(function(cacheName) {
          if (cacheName !== CACHE_NAME) {
            return caches.delete(cacheName);
          }
        })
      );
    })
  );
}); 