(() => {
    const infoMessageEl = document.querySelector('.info-message');

    if (infoMessageEl) {
        const expirationTime = 3000;

        setTimeout(() => {
            infoMessageEl.classList.add('hidden');
        }, expirationTime);
    }
})();