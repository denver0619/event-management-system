document.addEventListener('DOMContentLoaded', function () {
    initialLoadContent();
})

function initialLoadContent() {
    var eventId = document.getElementById('subcontent-container').getAttribute('event-id');

    // LOAD EVENT ATTENDEES 
    fetch(`/OrganizationEvents/EventAttendees?eventId=${eventId}`, {
        method: 'GET',  // Use GET method for initial load
        headers: {
            'Content-Type': 'application/json'
        }
    })
        .then(response => response.text())
        .then(data => {
            document.getElementById('subcontent-container').innerHTML = data;
            setupSubcontentButtons();
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
    var navigationElement = document.getElementById('current-event-information-navigation');

    // Determine the translateX value based on the 'type'
    var translateXValue;

    if (type.toLowerCase() === 'details') {
        translateXValue = 0;
    } else if (type.toLowerCase() === 'attendees') {
        translateXValue = 100;
    } else {
        // Default to 'attendancelog' if the type is unknown or not specified
        translateXValue = 200;
    }

    navigationElement.style.transform = `translateX(${translateXValue}%)`;



    loadSubContent(type);
}

function loadSubContent(type) {
    var eventId = document.getElementById('subcontent-container').getAttribute('event-id');

    fetch(`/OrganizationEvents/Event${type}?eventId=${eventId}`)
        .then(response => response.text())
        .then(data => {
            document.getElementById('subcontent-container').innerHTML = data;
            if (type == "Details") {
                loadEventDetailScript();
            }
        })
        .catch(error => console.error('Error:', error));
};


function loadEventDetailScript() {

    var eventNatureId = parseInt(document.getElementById('eventNature').getAttribute('data-event-nature-id'));
    var dropdown = document.getElementById('eventNature');

    console.log(eventNatureId)

    // Set the option with the matching value as selected
    var selectedOption = dropdown.querySelector('option[value="' + eventNatureId + '"]');
    if (selectedOption) {
        selectedOption.selected = true;
    }

    setupEditButton();


    function setupEditButton(){
        var editBtn = document.getElementById('edit-btn')

        editBtn.addEventListener('click', function () {
            gatherEditData();
        }
    }

    function gatherEditData() {
        var eventId = document.getElementById('subcontent-container').getAttribute('event-id');
        var organizationId = document.getElementById('subcontent-container').getAttribute('organization-id');
        var eventTitle = document.getElementById('eventTitle').value;
        var startDateTime = document.getElementById('startDateTime').value;
        var endDateTime = document.getElementById('endDateTime').value;
        var venue = document.getElementById('venue').value;
        var participantNumber = document.getElementById('participantNumber').value;

        var eventNatureDropdown = document.getElementById('eventNature');
        var eventNature = eventNatureDropdown.value;

        var eventType = document.getElementById('eventType').value;
        var contactPerson = document.getElementById('contactPerson').value;
        var contactNumber = document.getElementById('contactNumber').value;
        var feedbackLink = document.getElementById('feedbackLink').value;
        var paymentLink = document.getElementById('paymentLink').value;
        var description = document.getElementById('description').value;

        var isError = false;
        if (eventTitle === '') {
            applyErrorStyles('eventTitle');
            isError = true;
        } else {
            resetErrorStyles('eventTitle');
        }

        if (startDateTime === '') {
            applyErrorStyles('startDateTime');
            isError = true;
        } else {
            resetErrorStyles('startDateTime');
        }

        if (endDateTime === '') {
            applyErrorStyles('endDateTime');
            isError = true;
        } else {
            resetErrorStyles('endDateTime');
        }

        if (venue === '') {
            applyErrorStyles('venue');
            isError = true;
        } else {
            resetErrorStyles('venue');
        }

        if (participantNumber === '') {
            applyErrorStyles('participantNumber');
            isError = true;
        } else {
            resetErrorStyles('participantNumber');
        }

        if (eventNature === '') {
            applyErrorStyles('eventNature');
            isError = true;
        } else {
            resetErrorStyles('eventNature');
        }

        if (typeOfEvent === '') {
            applyErrorStyles('typeOfEvent');
            isError = true;
        } else {
            resetErrorStyles('typeOfEvent');
        }

        if (contactPerson === '') {
            applyErrorStyles('contactPerson');
            isError = true;
        } else {
            resetErrorStyles('contactPerson');
        }

        if (contactNumber === '') {
            applyErrorStyles('contactNumber');
            isError = true;
        } else {
            resetErrorStyles('contactNumber');
        }

        if (description === '') {
            applyErrorStyles('description');
            isError = true;
        } else {
            resetErrorStyles('description');
        }


        var eventDetails = {
            EventID: eventId,
            EventNatureID: eventNature,
            EventStatusID: "1",
            OrganizationID: organizationId,
            DatePosted: Date.now,
            DateStart: startDateTime,
            DateEnd: endDateTime,
            Venue: venue,
            Title: eventTitle,
            ParticipantNumber: 600,
            EventType: eventType,
            ContactPerson: "Jaeia Mikaella Apad",
            ContactNumber: "09463571592",
            FeedbackLink: "sample1.com",
            PaymentLink: "sample2.com",
            Description: "napakalapet",
            Image: "",
        };
    }



}