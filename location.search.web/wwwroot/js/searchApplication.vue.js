const vueApp = new Vue({
    el: '#app',
    data() {
        return {
            pageSize: 10,
            distance: 100,
            lat: null,
            long: null,
            locations: [],
            selectedSuggestionId: 1,
            locationSuggestions: [
                {
                  "id": 1,
                  "name": "Amsterdam museumplein",
                  "lat": 52.35867345,
                  "long": 4.88282308,
                },
                {
                    "id": 2,
                    "name": "Zaandam",
                    "lat": 52.4424926,
                    "long": 4.8298607,
                },
                {
                    "id": 3,
                    "name": "London Tower bridge",
                    "lat": 51.50549775,
                    "long": -0.07536088,
                },
                {
                    "id": 4,
                    "name": "Bergen aan zee",
                    "lat": 52.65706535,
                    "long": 4.62719841,
                }
              ]
        }
    },
    created: function () {
        this.selectSuggestion();
    },
    methods: {
        selectSuggestion(){
            var selectedOption = this.locationSuggestions.find(x => x.id === this.selectedSuggestionId)

            this.lat = selectedOption.lat;
            this.long = selectedOption.long;
            
            this.SearchLocation();

        },

        SearchLocation() {

            debugger;
            var request = {
                lat: this.lat,
                long: this.long,
                pageSize: this.pageSize,
                distance: this.distance
            };

            axios.post(`LocationSearch`, request, {
                
                headers: {
                    'Content-Type': 'application/json',
                    'Accept': 'application/json'
                }}).then(response => {
                    this.locations = response.data;
                }, err => {
                    console.error(err);
                    this.locations = null;
                });
        },
    }
});
