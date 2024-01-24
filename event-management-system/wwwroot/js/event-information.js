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
            loadAttendeesScript();
        })
        .catch(error => console.error('Error:', error));
}


function setupSubcontentButtons() {
    var buttons = document.querySelectorAll('.content-navigation button');
    buttons.forEach(function (button) {
        button.addEventListener('click', function () {
            var eventType = button.getAttribute('data-type');
            loadContent(eventType);
            console.log(eventType)
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

        // Check if there are no rows in the table
        if (rows.length === 0) {
            console.log('No rows in the table.');
            return;
        }

        rows.forEach(function (row) {
            var textContent = row.textContent.toLowerCase();
            row.style.display = textContent.includes(searchText) ? 'table-row' : 'none';
        });
    }





    // Add event listeners for time-in buttons
    var timeInButtons = document.querySelectorAll('.time-in-btn');
    timeInButtons.forEach(function (button) {
        button.addEventListener('click', function () {
            handleTimeButtonClick(button, 'time-in');
        });
    });

    var timeOutButtons = document.querySelectorAll('.time-out-btn');
    timeOutButtons.forEach(function (button) {
        button.addEventListener('click', function () {
            handleTimeButtonClick(button, 'time-out');
        });
    });

    // Add event listeners for time-out buttons
/*    var timeOutButtons = document.querySelectorAll('.time-out-btn');
    timeOutButtons.forEach(function (button) {
        button.addEventListener('click', function () {
            handleTimeButtonClick(button, 'time-out');
        });
    });

    function handleTimeButtonClick(button, eventType) {
        // Get the current time
        var currentTime = new Date().toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' });

        // Traverse DOM to find the corresponding row
        var row = button.closest('tr');

        // Update the corresponding time column in the row
        var timeIndex = eventType === 'time-in' ? 4 : 4; // Assuming time-in column index is 4, and time-out column index is 5
        row.cells[timeIndex].textContent = currentTime;

        if (eventType == "time-in") {
            // Extract data from the row
            var rowData = {
                StudentId: row.cells[0].textContent,
                Name: row.cells[1].textContent,
                YearLevel: row.cells[2].textContent,
                Date: row.cells[3].textContent,
                TimeIn: currentTime
            }
        } else if (eventType == "time-out") {
            // Extract data from the row
            var rowData = {
                StudentId: row.cells[0].textContent,
                Name: row.cells[1].textContent,
                YearLevel: row.cells[2].textContent,
                Date: row.cells[3].textContent,
                TimeOut: currentTime
            }
        }
        

        console.log(rowData)

        // Send data to the controller (you need to implement this part)
        sendToController(rowData);
    }*/

    function handleTimeButtonClick(button, eventType) {
        console.log(eventType)
        // Traverse DOM to find the corresponding row
        var row = button.closest('tr');

        // Get the corresponding date and time column indices
        var dateIndex = 5;
        var timeIndex = 6;

        // Check if there are contents in column 3 and 4
        if (row.cells[dateIndex].textContent.trim() !== '' && row.cells[timeIndex].textContent.trim() !== '') {
            // If there are contents, disable the button and return
            button.disabled = true;
            button.style.background = "gray";
            button.style.cursor = "default";
            return;
        }

        // If columns 3 and 4 are empty, proceed to update them
        // Get the current date
        var currentDate = new Date().toLocaleDateString();

        // Update the corresponding date column in the row
        row.cells[dateIndex].textContent = currentDate;

        // Get the current time
        var currentTime = new Date().toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' });

        // Update the corresponding time column in the row
        row.cells[timeIndex].textContent = currentTime;

        // Extract data from the row
        if (eventType == "time-in") {
            var rowData = {
                TimeInID: row.cells[0].textContent,
                TicketID: row.cells[1].textContent,
                /*TimeIn: currentDate + " " + currentTime,*/
                TimeIn: Date.now,
                IsIn: true

            };

            sendToTimeInController(rowData);
        }
        else if (eventType == "time-out")
        {
            var rowData = {
                TimeOutID: row.cells[0].textContent,
                TicketID: row.cells[1].textContent,
                /*TimeOut: currentDate + " " + currentTime,*/
                TimeOut: Date.now,
                IsOut: true
            };

            sendToTimeOutController(rowData);
        }
        

        console.log(rowData);

        // Send data to the controller (you need to implement this part)
        

        // Disable the button
        button.disabled = true;
        button.style.background = "gray";
        button.style.cursor = "default";
    }

    function sendToTimeInController(data) {
        // Implement your code to send data to the controller using AJAX or fetch
        // For example, you can use the Fetch API:
        fetch('/OrganizationEvents/TimeInAttendanceLog', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(data),
        })
            .then(response => response.json())
            .then(data => {
                console.log('Success:', data);
                // Handle success response from the controller
            })
            .catch((error) => {
                console.error('Error:', error);
                // Handle error
            });
    }
    function sendToTimeOutController(data) {
        // Implement your code to send data to the controller using AJAX or fetch
        // For example, you can use the Fetch API:
        fetch('/OrganizationEvents/TimeOutAttendanceLog', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(data),
        })
            .then(response => response.json())
            .then(data => {
                console.log('Success:', data);
                // Handle success response from the controller
            })
            .catch((error) => {
                console.error('Error:', error);
                // Handle error
            });
    }
}

function loadAttendeesScript() {
    console.log("attendees")
    var approveCheckboxes = document.querySelectorAll('input[name="approve-checkbox"]');
    var eventId = document.getElementById('subcontent-container').getAttribute('event-id');

    approveCheckboxes.forEach(function (checkbox) {
        checkbox.addEventListener('change', function () {
            if (checkbox.checked) {
                // Traverse DOM to find the corresponding row
                var row = checkbox.closest('tr');

                // Extract data from the row
                var eventAttendeeID = row.cells[0].textContent;  
                var studentId = row.cells[1].textContent;  
                var name = row.cells[2].textContent;       
                var yearLevel = row.cells[3].textContent;  
                var email = row.cells[4].textContent;      
                var contact = row.cells[5].textContent;    

                // Send data to the server (you need to implement this part)
                var attendeeInfo = {
                    EventAttendeeID: eventAttendeeID,
                    StudentID: studentId,
                    EventID: eventId,
                    IsApproved: true
                };
                console.log("if")
            } else {
                var row = checkbox.closest('tr');

                // Extract data from the row
                var eventAttendeeID = row.cells[0].textContent;
                var studentId = row.cells[1].textContent;
                var name = row.cells[2].textContent;
                var yearLevel = row.cells[3].textContent;
                var email = row.cells[4].textContent;
                var contact = row.cells[5].textContent;    

                // Send data to the server (you need to implement this part)
                var attendeeInfo = {
                    EventAttendeeID: eventAttendeeID,
                    StudentID: studentId,
                    EventID: eventId,
                    IsApproved: false
                };
                console.log("else")

            }

            sendToServer(attendeeInfo);
            console.log(attendeeInfo);
        });
    });


    var searchInput = document.getElementById('search-input');
    searchInput.addEventListener('input', function () {
        filterTable('event-attendees-table', searchInput.value);
    });


    function filterTable(tableId, searchText) {
        var rows = document.querySelectorAll('#' + tableId + ' tbody tr');

        // Check if there are no rows in the table
        if (rows.length === 0) {
            console.log('No rows in the table.');
            return;
        }

        rows.forEach(function (row) {
            var textContent = row.textContent.toLowerCase();
            row.style.display = textContent.includes(searchText) ? 'table-row' : 'none';
        });
    }


    function sendToServer(attendeeInfo) {
        console.log(attendeeInfo);


        // Implement your code to send data to the server using AJAX or fetch
        // For example, you can use the Fetch API:
        fetch('/OrganizationEvents/UpdateAttendeeStatus', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(attendeeInfo),
        })
            .then(response => response.json())
            .then(data => {
                console.log('Success:', data);
                // Handle success response from the server
            })
            .catch((error) => {
                console.error('Error:', error);
                // Handle error
            });
    }


    var startEventBtn = document.getElementById('start-event-btn');
    startEventBtn.addEventListener('click', function () {
        CreateTicket(eventId);
    })

    function CreateTicket(eventId) {
        console.log(eventId);
        fetch('/OrganizationEvents/CreateTicket', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ EventID: eventId })  // Convert the object to JSON string
        })
            .then(response => response.json())
            .then(data => {
                console.log('Success:', data);
                // Handle success response from the server
            })
            .catch(error => {
                console.error('Error:', error);
                // Handle error
            });
    }


}