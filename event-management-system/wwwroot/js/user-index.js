document.addEventListener('DOMContentLoaded', function () {
    setupCardRedirect();
})

function setupCardRedirect() {
    var eventCards = document.querySelectorAll('.event-card');

    eventCards.forEach(function (card) {
        card.addEventListener('click', function () {
            var eventID = card.getAttribute('event-id');

            // Get query data
            var queryString = window.location.search;

            redirectToEventMain(eventID, queryString);
        });
    });
}

function redirectToEventMain(eventID, queryString) {
    // Remove the leading "?" from the queryString if it exists
    queryString = queryString.startsWith('?') ? queryString.substring(1) : queryString;

    var url = '/UserEvents/EventInfo?id=' + encodeURIComponent(eventID);

    // Append the queryString if it's not empty
    if (queryString) {
        url += '&' + queryString;
    }

    // Redirect to the new URL
    window.location.href = url;
}