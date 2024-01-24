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
            loadAttendeesScript();
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
            if (type == "AttendanceLog") {
                loadAttendanceLogScript();
            }
            if (type == "Attendees") {
                loadAttendeesScript();
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

        editBtn.addEventListener('click', function (e) {
            e.preventDefault();
            gatherEditData();
        })
    }

    function gatherEditData() {
        var eventId = document.getElementById('subcontent-container').getAttribute('event-id');
        var datePosted = document.getElementById('event-details-field').getAttribute('date-posted');
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

        if (eventType === '') {
            applyErrorStyles('eventType');
            isError = true;
        } else {
            resetErrorStyles('eventType');
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

        console.log(datePosted);

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
            ContactPerson: contactPerson,
            ContactNumber: contactNumber,
            FeedbackLink: feedbackLink,
            PaymentLink: paymentLink,
            Description: description,
            Image: "",
        };

        console.log(eventDetails)

        sendEditData(eventDetails)
    }

    function sendEditData(eventDetails) {
        fetch('/OrganizationEvents/EditEvent', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(eventDetails)
        })
    }

    // Function to apply error styles to input fields
    function applyErrorStyles(elementId) {
        var element = document.getElementById(elementId);
        element.style.boxShadow = '0 0 5px 2px rgba(255, 255, 255, 0.5)';
        element.style.border = '1px solid red';
        element.classList.add('shake'); // Adding a shake class for animation
        setTimeout(function () {
            element.classList.remove('shake'); // Remove the shake class after the animation ends
        }, 500);
    }

    function resetErrorStyles(elementId) {
        var element = document.getElementById(elementId);
        element.style.border = '1px solid #ccc'; // Reset the border
        element.style.boxShadow = "none";

    }

}

function loadAttendanceLogScript() {
    var searchInputTimeIn = document.getElementById('search-input-time-in');
    searchInputTimeIn.addEventListener('input', function () {
        filterTable('event-attendance-time-in-table', searchInputTimeIn.value);
    });

    // Function to perform search for time-out table
    var searchInputTimeOut = document.getElementById('search-input-time-out');
    searchInputTimeOut.addEventListener('input', function () {
        filterTable('event-attendance-time-out-table', searchInputTimeOut.value);
    });


    function filterTable(tableId, searchText) {
        var rows = document.querySelectorAll('#' + tableId + ' tbody tr');

        rows.forEach(function (row) {
            var textContent = row.textContent.toLowerCase();
            row.style.display = textContent.includes(searchText) ? 'table-row' : 'none';
        });
    }
}

function loadAttendeesScript() {
    console.log("attendees")
    var approveCheckboxes = document.querySelectorAll('input[name="approve-checkbox"]');

    approveCheckboxes.forEach(function (checkbox) {
        checkbox.addEventListener('change', function () {
            if (checkbox.checked) {
                // Traverse DOM to find the corresponding row
                var row = checkbox.closest('tr');

                // Extract data from the row
                var studentId = row.cells[0].textContent;  // Assuming Student ID is in the first cell
                var name = row.cells[1].textContent;       // Assuming Name is in the second cell
                var yearLevel = row.cells[2].textContent;  // Assuming Year Level is in the third cell
                var email = row.cells[3].textContent;      // Assuming Email is in the fourth cell
                var contact = row.cells[4].textContent;    // Assuming Contact is in the fifth cell

                // Send data to the server (you need to implement this part)
                sendToServer({
                    studentId: studentId,
                    name: name,
                    yearLevel: yearLevel,
                    email: email,
                    contact: contact,
                    isApprove: true
                });
            } else {
                var row = checkbox.closest('tr');

                // Extract data from the row
                var studentId = row.cells[0].textContent;  // Assuming Student ID is in the first cell
                var name = row.cells[1].textContent;       // Assuming Name is in the second cell
                var yearLevel = row.cells[2].textContent;  // Assuming Year Level is in the third cell
                var email = row.cells[3].textContent;      // Assuming Email is in the fourth cell
                var contact = row.cells[4].textContent;    // Assuming Contact is in the fifth cell

                // Send data to the server (you need to implement this part)
                sendToServer({
                    studentId: studentId,
                    name: name,
                    yearLevel: yearLevel,
                    email: email,
                    contact: contact,
                    isApprove: false
                });
            }
        });
    });


    var searchInput = document.getElementById('search-input');
    searchInput.addEventListener('input', function () {
        filterTable('event-attendees-table', searchInput.value);
    });


    function filterTable(tableId, searchText) {
        var rows = document.querySelectorAll('#' + tableId + ' tbody tr');

        rows.forEach(function (row) {
            var textContent = row.textContent.toLowerCase();
            row.style.display = textContent.includes(searchText) ? 'table-row' : 'none';
        });
    }


    function sendToServer(data) {
        console.log(data)

        // Implement your code to send data to the server using AJAX or fetch
        // For example, you can use the Fetch API:
        /*fetch('OrganizationEvents/UpdateAttendeeStatus', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(data),
        })
            .then(response => response.json())
            .then(data => {
                console.log('Success:', data);
                // Handle success response from the server
            })
            .catch((error) => {
                console.error('Error:', error);
                // Handle error
            });*/
    }
}