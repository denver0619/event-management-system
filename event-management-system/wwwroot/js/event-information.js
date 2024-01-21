document.addEventListener('DOMContentLoaded', function () {
    initialLoadContent();
})

function initialLoadContent() {
    var eventId = document.getElementById('subcontent-container').getAttribute('event-id');

    // LOAD EVENT ATTENDEES 
    fetch(`/Events/EventAttendees?eventId=${eventId}`)
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

    fetch(`/Events/Event${type}?eventId=${eventId}`)
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
    const previewContainer = document.getElementById('preview-container');
    setupFileUpload();

    function setupFileUpload() {
        const fileInput = document.getElementById('file-input');
        /*const previewContainer = document.getElementById('preview-container');*/

        fileInput.addEventListener('change', handleFileSelect);
    }

    /*function handleFileSelect(event) {

        const files = event.target.files;

        for (const file of files) {
            const reader = new FileReader();

            reader.onload = function (e) {
                const previewCard = createPreviewCard(e.target.result);
                previewContainer.appendChild(previewCard);
            };

            reader.readAsDataURL(file);
        }
    }*/

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
            // Clear existing preview cards
            clearPreviewContainer();

            const previewCard = createPreviewCard(e.target.result);
            previewContainer.appendChild(previewCard);
        };

        reader.readAsDataURL(file);

        console.log(file)
    }

    function clearPreviewContainer() {
        const existingPreviews = document.querySelectorAll('.preview-card');
        existingPreviews.forEach(preview => previewContainer.removeChild(preview));
    }

    function createPreviewCard(imageSrc) {
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

}