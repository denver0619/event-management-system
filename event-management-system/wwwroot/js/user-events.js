document.addEventListener('DOMContentLoaded', function () {
    initialLoadContent();
    setupSubcontentButtons();
})

function initialLoadContent() {
    fetch(`/UserEvents/EventsUpcoming`)
        .then(response => response.text())
        .then(data => {
            document.getElementById('subcontent-container').innerHTML = data;

            setupCardRedirect()
        })
        .catch(error => console.error('Error:', error));
}

function setupSubcontentButtons() {
    var buttons = document.querySelectorAll('.content-navigation button');

    buttons.forEach(function (button) {
        button.addEventListener('click', function () {
            var eventType = button.getAttribute('data-type');
            loadContent(eventType);
        });

    });
}


function loadContent(type) {
    var navigationElement = document.getElementById('current-event-list-navigation');

    // Determine the translateX value based on the 'type'
    var translateXValue;

    if (type.toLowerCase() === 'upcoming') {
        translateXValue = 0;
    } else if (type.toLowerCase() === 'previous') {
        translateXValue = 100;
    } else {
        // Default to 0 if the type is unknown or not specified
        translateXValue = 0;
    }

    navigationElement.style.transform = `translateX(${translateXValue}%)`;

    loadCategorySubContent(type);
}


function loadCategorySubContent(type) {
    fetch(`/UserEvents/Events${type}`)
        .then(response => response.text())
        .then(data => {
            document.getElementById('subcontent-container').innerHTML = data;
            setupCardRedirect();
        })
        .catch(error => console.error('Error:', error));
}

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





