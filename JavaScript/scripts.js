
/* Changes what file is shown*/
function changeFilePath(filePath, iframeLocation) {
    var iframe = document.getElementById(iframeLocation);
    iframe.src = filePath;
}


/* Scroll down*/
function scrollToMoreInfo(sectionId) {
    var moreInfoSection = document.getElementById(sectionId);
    moreInfoSection.scrollIntoView({ behavior: "smooth" });
}

/* Rotaing items*/
document.addEventListener('DOMContentLoaded', function () {
    const items = document.querySelectorAll('.item');

    // Customizable variables
    const tiltSensitivity = 20; // Lower values make the tilt more sensitive
    const tiltAmount = 3; // The amount of tilt in degrees

    items.forEach(item => {
        // Store the initial transform state
        const initialTransform = item.style.transform || '';

        item.addEventListener('mousemove', function (e) {
            const rect = item.getBoundingClientRect();
            const centerX = rect.left + rect.width / 2;
            const centerY = rect.top + rect.height / 2;
            // Calculate tilt angles for both horizontal and vertical movements
            const angleX = (e.clientY - centerY) / tiltSensitivity;
            const angleY = (e.clientX - centerX) / tiltSensitivity;
            // Apply the tilt effect in all directions
            item.style.transform = `${initialTransform} translateY(-15px) rotateX(${angleX * tiltAmount}deg) rotateY(${angleY * tiltAmount}deg)`;
        });

        item.addEventListener('mouseleave', function () {
            // Reset the transform to its initial state when the mouse leaves
            item.style.transform = initialTransform;
        });
    });
});


// Background color, and font color
document.addEventListener('DOMContentLoaded', function () {
    const toggleButton = document.getElementById('toggleBackground');
    let isWhite = false; // Initial background color is black
    const initiallyBlackElements = []; // Array to store initially black elements

    // Function to check if an element's color is black
    function isColorBlack(element) {
        return window.getComputedStyle(element).color === 'rgb(0, 0, 0)';
    }

    // Store initially black elements
    document.querySelectorAll('p, h1, h2, h3, h4, h5, h6, div, span, a, iframe, button').forEach(element => {
        if (isColorBlack(element)) {
            initiallyBlackElements.push(element);
        }
    });

    toggleButton.addEventListener('click', function () {
        if (isWhite) {
            document.body.style.backgroundColor = 'black';
            initiallyBlackElements.forEach(el => el.style.color = 'white');
            isWhite = false;
        } else {
            document.body.style.backgroundColor = 'white';
            initiallyBlackElements.forEach(el => el.style.color = 'black');
            isWhite = true;
        }
    });
});
