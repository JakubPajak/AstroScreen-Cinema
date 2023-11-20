// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function makeAuthenticatedRequest(url, method, data) {
    const headers = {
        'Content-Type': 'application/json',
    };

    // Check if the access token is available
    if (window.accessToken) {
        headers['Authorization'] = 'Bearer ' + window.accessToken;
    }

    return fetch(url, {
        method: method,
        headers: headers,
        body: data ? JSON.stringify(data) : undefined,
    });
}
