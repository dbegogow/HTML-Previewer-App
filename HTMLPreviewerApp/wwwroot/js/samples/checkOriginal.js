(() => {
    const messageContainer = document.querySelector('.check-original-message');
    const message = document.querySelector('.check-original-message > p');

    const expirationTime = 2000;

    const check = () => {
        const id = document.getElementById('sample-id').value;
        const code = document.getElementById('code').value;

        const token = document.querySelector("input[name='__RequestVerificationToken']").value;

        fetch('/api/checkOriginal',
            {
                method: 'POST',
                headers: {
                    "Content-Type": "application/json",
                    'RequestVerificationToken': token
                },
                body: JSON.stringify({ id: id, code: code })
            })
            .then(res => res.json())
            .then(res => {
                if (res) {
                    message.textContent = 'Your new code is the same like the original';
                } else {
                    message.textContent = 'Your new code is not the same like the original';
                }

                messageContainer.classList.remove('hidden');

                setTimeout(() => {
                    messageContainer.classList.add('hidden');
                }, expirationTime);
            })
            .catch(err => alert(err.message));
    }

    const checkBtn = document.getElementById('check-button');

    if (checkBtn !== null && checkBtn !== undefined) {
        checkBtn.addEventListener('click', check);
    }
})();