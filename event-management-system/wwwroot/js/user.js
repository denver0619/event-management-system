document.addEventListener('DOMContentLoaded', function () {
    // Get the value of the 'userId' parameter from the query string
    var userId = getQueryStringParameter('userId');

    // Now you can use the 'userId' value as needed
    console.log('User ID:', userId);

    // If you want to dynamically set the 'userId' in your links, you can do something like this:
    var links = document.querySelectorAll('.nav-btn');
    links.forEach(function (link) {
        // Add or update the 'userId' parameter in the href
        link.href = updateQueryStringParameter(link.href, 'userId', userId);
    });
});

// Helper function to get the value of a query parameter from the current URL
function getQueryStringParameter(name) {
    // Get the query string portion of the URL
    var queryString = window.location.search.substring(1);

    // Split the query string into key-value pairs
    var queryParams = queryString.split('&');

    // Iterate through the key-value pairs to find the parameter with the specified name
    for (var i = 0; i < queryParams.length; i++) {
        var pair = queryParams[i].split('=');
        if (pair[0] === name) {
            // Return the value of the parameter
            return decodeURIComponent(pair[1]);
        }
    }

    // Return null if the parameter is not found
    return null;
}

// Helper function to add or update a query parameter in a URL
function updateQueryStringParameter(url, key, value) {
    var regex = new RegExp("([?&])" + key + "=.*?(&|$)", "i");
    var separator = url.indexOf('?') !== -1 ? "&" : "?";

    if (url.match(regex)) {
        return url.replace(regex, '$1' + key + "=" + value + '$2');
    } else {
        return url + separator + key + "=" + value;
    }
}