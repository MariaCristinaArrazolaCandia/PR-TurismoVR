function showMap() {
    var map = new google.maps.Map(document.getElementById('map'), {
        center: { lat: -17.331614, lng: -66.2400915 },
        zoom: 14,
        minZoom: 14
    });

    var marker = new google.maps.Marker({
        map: map,
        position: { lat: -17.331614, lng: -66.2400915 },
        draggable: true
    });

    google.maps.event.addListener(marker, 'dragend', function (event) {
        document.getElementById('latitude').value = event.latLng.lat();
        document.getElementById('longitude').value = event.latLng.lng();
        document.getElementById('latitude-label').textContent = event.latLng.lat();
        document.getElementById('longitude-label').textContent = event.latLng.lng();
        document.getElementById('location-labels').style.display = 'block';
    });
}
