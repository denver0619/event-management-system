let imageBlob;

document.addEventListener('DOMContentLoaded', function () {
    setupFileUpload();
    setupSubmitButton();
})

function setupFileUpload() {
    const fileInput = document.getElementById('file-input');

    fileInput.addEventListener('change', handleFileSelect);
    fileInput.addEventListener('change', loadImageToUI);
}

function handleFileSelect(event) {
    const files = event.target.files;

    // Ensure only one file is selected
    if (files.length !== 1) {
        alert('Please select only one image.');
        return;
    }

    const file = files[0];
    const reader = new FileReader();
    reader.onload = function (e) {
        const arrayBuffer = e.target.result;
        const byteArray = new Uint8Array(arrayBuffer);
        imageBlob = new Blob([byteArray], { type: file.type });

        setupSubmitButton(imageBlob);
    };
    reader.readAsArrayBuffer(file);
}

function loadImageToUI(event) {
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
}

function convertImageToByteArray(imageBlob) {
    const reader = new FileReader();
    reader.onload = function (e) {
        const arrayBuffer = e.target.result;
        const byteArray = new Uint8Array(arrayBuffer);

        // Log information about the blob file or its contents
        console.log('Blob Image Data:', byteArray);
        console.log('Blob Size:', byteArray.length);

        // Pass the byte array to validationCheck (you can also pass it to other functions as needed)
        setupSubmitButton(byteArray);
    };

    reader.readAsArrayBuffer(imageBlob);
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

function setupSubmitButton(imageBlob) {
    var submitBtn = document.getElementById('submit-event');
    submitBtn.onclick = function () {
        validationCheck(imageBlob);
    }
}

function validationCheck(imageData) {
    /*var Image = byteArray;
        console.log(byte);
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
    }*/
    

    // Other validation and data processing logic...
    var eventDetails = {
        EventID: '',
        EventNatureID: "1100003",
        EventStatusID: "60001",
        OrganizationID: "1",
        DatePosted: Date.now,
        DateStart: "2024-02-14",
        DateEnd: "2024-02-15",
        Venue: "People Center",
        Title: "Bataan Foundation Day",
        ParticipantNumber: 600,
        EventType: "Celebration",
        ContactPerson: "Jaeia Mikaella Apad",
        ContactNumber: "09463571592",
        FeedbackLink: "sample1.com",
        PaymentLink: "sample2.com",
        Description: "napakalapet",
        Image: "",
    };

    sendTextData(eventDetails);
    /*sendImageData(imageBlob);
    sendData(imageBlob);*/
}

function sendTextData(eventDetails) {
    fetch('/OrganizationEvents/SendTextData', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json', // Set content type to JSON
        },
        body: JSON.stringify(eventDetails), // Send as JSON string
    })
        .then(response => {
            if (response.ok) {
                return response.json();
            } else {
                throw new Error('Failed to send text data');
            }
        })
        .then(data => {
            console.log('Received data:', data);
        })
        .catch(error => {
            console.error('Error:', error);
        });
}












