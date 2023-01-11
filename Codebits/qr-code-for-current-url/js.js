// Create a QR code object
var qr = new QRious({
    value: window.location.href
  });
  
  // Get the QR code as a PNG image
  var qrCodeImage = qr.toDataURL();
  
  // Create an <img> tag with the QR code image as the source
  var img = document.createElement('img');
  img.src = qrCodeImage;
  
  // Add the <img> tag to the page
  document.body.appendChild(img);