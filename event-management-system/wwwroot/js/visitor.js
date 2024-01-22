document.addEventListener('DOMContentLoaded', function () {
    setupCardRedirect();
})

function setupCardRedirect() {
    console.log(1)
    var eventCards = document.querySelectorAll('.event-card');

    eventCards.forEach(function (card) {
        card.addEventListener('click', function () {
            console.log(1)
            var eventID = card.getAttribute('event-id');
            redirectToEventMain(eventID);
        });
    });
}


function redirectToEventMain(eventID) {
    var url = '/VisitorEvents/EventInfo?id=' + encodeURIComponent(eventID);

    // Redirect to the new URL
    window.location.href = url;
}
