document.addEventListener('DOMContentLoaded', function (){
    var registerInfo = getUserIdFromQueryString();
    console.log(registerInfo)
    setupRegisterBtn(registerInfo);
})

function getUserIdFromQueryString() {
    var queryString = window.location.search;
    var urlParams = new URLSearchParams(queryString);

    // Replace 'userId' with the actual query parameter name you are using
    var userId = urlParams.get('userId');
    var eventId = urlParams.get('id');

    var registerInfo = {
        UserID: userId,
        eventID: eventId
    }

    return registerInfo;
}

function setupRegisterBtn(registerInfo) {
    var registerBtn = document.getElementById('register-btn')

    registerBtn.addEventListener('click', function () {
        console.log("click");
        registerUser(registerInfo);
    })
}



function registerUser(registerInfo) {
    fetch('/UserEvents/RegisterUser', {
        method: 'POST',
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(registerInfo)
    })

}