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
    console.log(imageBlob);

    // Other validation and data processing logic...
    /*var eventDetails = {
        
        EventID: '',
        EventNatureID: "1100003",
        EventStatusID: "60001",
        OrganizationID: "1",
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

    }*/

    sendImageData(imageBlob);
}

function sendImageData(imageBlob) {
    const formData = new FormData();

    // Append the image blob
    formData.append('Image', imageBlob, 'image.jpg');

    // Append the event details
    const eventDetails = {
        EventID: '',
        EventNatureID: "1100003",
        EventStatusID: "60001",
        OrganizationID: "1",
        Venue: "People Center",
        Title: "Bataan Foundation Day",
        ParticipantNumber: 600,
        EventType: "Celebration",
        ContactPerson: "Jaeia Mikaella Apad",
        ContactNumber: "09463571592",
        FeedbackLink: "sample1.com",
        PaymentLink: "sample2.com",
        Description: "napakalapet",
    };

    // Convert the event details to a JSON string and append it to the form data
    formData.append('EventDetails', JSON.stringify(eventDetails));

    fetch('/OrganizationEvents/SendImageData', {
        method: 'POST',
        body: formData
    })
    .then(response => {
        if (response.ok) {
            return response.json();
        } else {
            throw new Error('Failed to send image data');
        }
    })
    .then(data => {
        console.log('Received data:', data);

        const imageElement = document.createElement('img');
        imageElement.src = 'data:image/jpeg;base64,' + data.ImageData;
        document.body.appendChild(imageElement);
    })
    .catch(error => {
        console.error('Error:', error);
    });
}












