document.addEventListener('DOMContentLoaded', function () {
    setupLogin();
})

function setupLogin() {
    var loginBtn = document.getElementById('loginBtn');
    loginBtn.addEventListener('click', function () {
        var email = document.getElementById('email').value;
        var password = document.getElementById('password').value;

        userCredential = {
            Email: email,
            Password: password,
        }

        console.log(userCredential)
        sendLoginData(userCredential);
    })
}

function sendLoginData(data) {
    fetch('/VisitorHome/ValidateLogin', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(data)
    })
        .then(response => response.json())
        .then(data => {
            if (data.redirectTo) {

                window.location.href = data.redirectTo;
            } else {
                // Handle other responses
                console.log("Login successful");
            }

        })
        .catch(error => {
            // Handle network or other errors
            console.error('Error:', error);
        });
}