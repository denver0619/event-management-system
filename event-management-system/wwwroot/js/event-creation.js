/*let imageByteArray;
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

    console.log(event.target.files)
    // Ensure only one file is selected
    if (files.length !== 1) {
        alert('Please select only one image.');
        return;
    }

    const file = files[0];
    const reader = new FileReader();
    reader.readAsArrayBuffer(file);
    reader.onload = function (e) {
        var byte = new Uint8Array(e.target.result)
        setupSubmitButton(byte)
        console.log("handalefileselect" + byte)
    };
    //reader.readAsDataURL(file);
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

        // Convert the uploaded image to a byte array

    };

    reader.readAsDataURL(file);
}

*//*function convertImageToByteArray(imageSrc) {
    const img = new Image();
    img.onload = function () {
        const canvas = document.createElement('canvas');
        canvas.width = img.width;
        canvas.height = img.height;
        const ctx = canvas.getContext('2d');
        ctx.drawImage(img, 0, 0, img.width, img.height);

        const imageData = ctx.getImageData(0, 0, img.width, img.height).data;

        // Convert the image data to a byte array
        imageByteArray = Array.from(imageData);

        // Log information about the blob file or its contents
        console.log("BLOB")
        console.log('Blob Image Data:', imageData);
        console.log('Blob Image Width:', img.width);
        console.log('Blob Image Height:', img.height);
        console.log("BLOB")


        // Pass the byte array to validationCheck (you can also pass it to other functions as needed)
        setupSubmitButton(imageByteArray);
    };

    img.src = imageSrc;
}*//*

function convertImageToByteArray(imageSrc) {
    const img = new Image();
    img.onload = function () {
        const canvas = document.createElement('canvas');
        canvas.width = img.width;
        canvas.height = img.height;
        const ctx = canvas.getContext('2d');
        ctx.drawImage(img, 0, 0, img.width, img.height);

        const imageData = ctx.getImageData(0, 0, img.width, img.height).data;

        // Log information about the blob file or its contents
        console.log('Blob Image Data:', imageData);
        console.log('Blob Image Width:', img.width);
        console.log('Blob Image Height:', img.height);

        // Convert the image data to a byte array
        imageByteArray = Array.from(imageData);

        // Pass the byte array to validationCheck (you can also pass it to other functions as needed)
        setupSubmitButton(imageByteArray);
    };

    // Use a data URL instead of directly setting the blob URL
    img.src = imageSrc;
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


function setupSubmitButton(byte) {

    console.log("setupsubmit" + byte)
    var submitBtn = document.getElementById('submit-event');
    submitBtn.onclick = function () {
        console.log("inisde setup" + byte)

        validationCheck(byte)
    }
   //submitBtn.addEventListener('click', validationCheck(byte));

}

function validationCheck(byte) {
    *//*const byteArray = [];
    Object.keys(byte).forEach((key) => {
        const byteForKey = contentUint8Array[key];
        byteArray.push(byteForKey);
    });
    var Image = byteArray;*//*
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
    *//*if (eventTitle === '') {
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
    }*//*

    var organizationID = getOrganizationID();

    *//*var eventDetails = {     
        EventID: '',
        EventNature: eventNature,
        EventStatusId: 60001,
        OrganizationID: organizationID,
        DatePosted: '',
        DateStart: startDateTime,
        DateEnd: endDateTime,
        Venue: venue,
        Image: Image,
        Title: eventTitle,      
        ParticipantNumber: participantNumber, 
        EventType: typeOfEvent,
        ContactPerson: contactPerson,
        ContactNumber: contactNumber,
        FeedbackLink: feedbackLink,
        PaymentLink: paymentLink,
        Description: description,
    }*//*

    var eventDetails = {
        
        *//*EventID: '',
        EventNatureID: "1100003",
        EventStatusID: "60001",
        OrganizationID: organizationID,
        OrganizationID: "1",*//*
        Image: btoa(new Uint8Array(byte).reduce(
            function (data, arrayBuffer) {
                return data + String.fromCharCode(arrayBuffer);
            },
            ''
        )),
       *//* DatePosted: '',
        DateStart: "2024-02-14",
        DateEnd: "2024-02-15",*//*
        Venue: "People Center",
        Title: "Bataan Foundation Day",      
        ParticipantNumber: 600, 
        EventType: "Celebration",
        ContactPerson: "Jaeia Mikaella Apad",
        ContactNumber: "09463571592",
        FeedbackLink: "sample1.com",
        PaymentLink: "sample2.com",
        Description: "napakalapet",

    }

    console.log(eventDetails);

    if (isError == false) {
        sendData(btoa(new Uint8Array(byte).reduce(
            function (data, arrayBuffer) {
                return data + String.fromCharCode(arrayBuffer);
            },
            ''
        )));
    }

}

function getOrganizationID() {
    
        var queryString = window.location.search;
        var urlParams = new URLSearchParams(queryString);

        // Replace 'userId' with the actual query parameter name you are using
        var organizationID = urlParams.get('userId');


        return organizationID;
    
}

function sendData(eventDetails) {

    console.log(eventDetails)

    fetch('/OrganizationEvents/SendEventData', {
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
}*/

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

function setupSubmitButton(data) {
    var submitBtn = document.getElementById('submit-event');
    submitBtn.onclick = function () {
        validationCheck(data);
    }
}

function validationCheck(data) {
    console.log(data);

    // Other validation and data processing logic...

    sendData(data);
}

function sendData(imageBlob) {
    const formData = new FormData();
    formData.append('image', imageBlob, 'image.jpg');

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

            const imageData = data && data.imageData; 

            //if (imageData) {
                const imageElement = document.createElement('img');
                imageElement.src = 'data:image/jpeg;base64,' + encodeURIComponent(imageData);
                document.body.appendChild(imageElement);
            //} else {
            //    console.error('Invalid response format from the server');
            //}
        })
        .catch(error => {
            console.error('Error:', error);
        });
}







