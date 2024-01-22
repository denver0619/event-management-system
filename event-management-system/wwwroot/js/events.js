document.addEventListener('DOMContentLoaded', function () {
    console.log(1)
    persistQueryData();
    initialLoadContent();
    setupSubcontentButtons();
})

function initialLoadContent() {
    console.log("initial")
    var queryString = getQueryData();
    fetch(`/OrganizationEvents/EventsUpcoming${queryString}`)
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
    var queryString = getQueryData();
    fetch(`/OrganizationEvents/Events${type}${queryString}`)
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

function getQueryData() {
    var currentQueryString = window.location.search;
    return currentQueryString;
}

function persistQueryData() {
    // Get the current query parameters
    var currentQueryString = window.location.search;

    // Attach a click event handler to the "Create Event" link
    document.getElementById('createEventLink').addEventListener('click', function () {
        // Get the href attribute of the link
        var linkHref = this.getAttribute('href');

        // Append the current query parameters to the link's href
        var updatedHref = linkHref + currentQueryString;

        // Set the updated href back to the link
        this.setAttribute('href', updatedHref);
    });
}


function redirectToEventMain(eventID, queryString) {
    // Remove the leading "?" from the queryString if it exists
    queryString = queryString.startsWith('?') ? queryString.substring(1) : queryString;

    var url = '/OrganizationEvents/EventMain?id=' + encodeURIComponent(eventID);

    // Append the queryString if it's not empty
    if (queryString) {
        url += '&' + queryString;
    }

    // Redirect to the new URL
    window.location.href = url;
}





