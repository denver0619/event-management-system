document.addEventListener('DOMContentLoaded', function () {
    initialLoadContent();
})

function initialLoadContent() {
    // LOAD EVENT ATTENDEES 
    fetch(`/Events/EventAttendees`)
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
    fetch(`/Events/Event${type}`)
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

    const fileInput = document.getElementById('file-input');
    const previewContainer = document.getElementById('preview-container');

    fileInput.addEventListener('change', handleFileSelect);

    function handleFileSelect(event) {
        const files = event.target.files;

        for (const file of files) {
            const reader = new FileReader();

            reader.onload = function (e) {
                const previewCard = createPreviewCard(e.target.result);
                previewContainer.appendChild(previewCard);
            };

            reader.readAsDataURL(file);
        }
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