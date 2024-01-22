document.addEventListener('DOMContentLoaded', function () {
    initialLoadContent();
    setupSubcontentButtons();
})

function initialLoadContent() {
    fetch(`/VisitorEvents/EventsUpcoming`)
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
    fetch(`/VisitorEvents/Events${type}`)
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
            var eventID = card.getAttribute('event-id'); // Assuming you have a data attribute for event ID
            redirectToEventMain(eventID);
        });
    });
}

function redirectToEventMain(EventID) {
    var url = '/VisitorEvents/EventInfo?id=' + encodeURIComponent(EventID);

    // Redirect to the new URL
    window.location.href = url;
}





