document.addEventListener('DOMContentLoaded', function () {
    setupFileUpload();
    setupSubmitButton();
})


function setupFileUpload() {
    const fileInput = document.getElementById('file-input');

    fileInput.addEventListener('change', handleFileSelect);
}

function handleFileSelect(event) {
    const previewContainer = document.getElementById('preview-container');
    const files = event.target.files;

    // Ensure only one file is selected
    if (files.length !== 1) {
        alert('Please select only one image.');
        return;
    }

    const file = files[0];
    const reader = new FileReader();

    reader.onload = function (e) {
        // Clear existing preview cards
        clearPreviewContainer();

        const previewCard = createPreviewCard(e.target.result);
        previewContainer.appendChild(previewCard);
    };

    reader.readAsDataURL(file);

    console.log(file)
}

function clearPreviewContainer() {
    const previewContainer = document.getElementById('preview-container');
    const existingPreviews = document.querySelectorAll('.preview-card');
    existingPreviews.forEach(preview => previewContainer.removeChild(preview));
}

function createPreviewCard(imageSrc) {
    const previewContainer = document.getElementById('preview-container');
    const previewCard = document.createElement('div');
    previewCard.className = 'preview-card';

    previewCard.innerHTML = `
            <span class="remove-button">&times; Remove</span>
            <img src="${imageSrc}" alt="Preview">
        `;

    const removeButton = previewCard.querySelector('.remove-button');
    removeButton.addEventListener('click', () => {
        previewContainer.removeChild(previewCard);
    });

    return previewCard;
}


function setupSubmitButton() {
    var submitBtn = document.getElementById('submit-event');

    submitBtn.addEventListener('click', function () {
        validationCheck();
    })

    
}

function validationCheck() {
    var eventTitle = document.getElementById('eventTitle').value;
    var startDateTime = document.getElementById('startDateTime').value;
    var endDateTime = document.getElementById('endDateTime').value;
    var venue = document.getElementById('venue').value;
    var participantNumber = document.getElementById('participantNumber').value;

    var eventNatureDropdown = document.getElementById('eventNature');
    var eventNature = eventNatureDropdown.value;

    var typeOfEvent = document.getElementById('typeOfEvent').value;
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
        eventTitle: eventTitle,
        startDateTime: startDateTime,
        endDateTime: endDateTime,
        venue: venue,
        participantNumber: participantNumber,
        eventNature: eventNature,
        typeOfEvent: typeOfEvent,
        contactPerson: contactPerson,
        contactNumber: contactNumber,
        feedbackLink: feedbackLink,
        paymentLink: paymentLink,
        description: description,
    }

    if (isError == false) {
        sendData(eventDetails);
    }

}

function sendData(eventDetails) {
    fetch('Events/SendEventData', {
        method: 'POST',
        header: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(eventDetails)
    })
}

function applyErrorStyles(elementId) {
    var element = document.getElementById(elementId);
    element.style.border = '2px solid red';
    element.style.boxShadow = '0 0 0 1px white, 0 0 0 1px white';
    element.classList.add('shake'); // Adding a shake class for animation
    setTimeout(function () {
        element.classList.remove('shake'); // Remove the shake class after the animation ends
    }, 500);
}

function resetErrorStyles(elementId) {
    var element = document.getElementById(elementId);
    element.style.border = 'none'; // Reset the border
}