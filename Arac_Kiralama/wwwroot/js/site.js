function updateColorPreview() {
    const r = document.getElementById('rSlider').value;
    const g = document.getElementById('gSlider').value;
    const b = document.getElementById('bSlider').value;

    document.getElementById('rValue').value = r;
    document.getElementById('gValue').value = g;
    document.getElementById('bValue').value = b;

    const rgbColor = `rgb(${r}, ${g}, ${b})`;
    document.getElementById('colorPreview').style.backgroundColor = rgbColor;
    document.getElementById('rgbCode').textContent = `RGB(${r}, ${g}, ${b})`;

    // Convert RGB to HEX
    const hexColor = rgbToHex(parseInt(r), parseInt(g), parseInt(b));
    document.getElementById('hexCode').textContent = hexColor;
}

function updateSlider(valueId, sliderId) {
    const value = document.getElementById(valueId).value;
    document.getElementById(sliderId).value = value;
    updateColorPreview();
}

function rgbToHex(r, g, b) {
    return "#" + ((1 << 24) + (r << 16) + (g << 8) + b).toString(16).slice(1).toUpperCase();
}

// Initialize color preview on page load
document.addEventListener('DOMContentLoaded', function () {
    updateColorPreview();
});