(() => {
    const resultEl = document.getElementById('result');

    const render = (e) => {
        const target = e.target;

        resultEl.innerHTML = target.value;
    };

    document.getElementById('code')
        .addEventListener('input', render);
})();