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
                }
              ]
        }
    },
    created: function () {
        this.SearchLocation();
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

            var request = new {
                lat: this.lat,
                long: this.long,
                pageSize: this.pageSize,
                distance: this.distance
            };

            axios.get(`LocationSearch`, request, {
                responseType: 'arraybuffer',
                headers: {
                    'Content-Type': 'application/json',
                    'Accept': 'application/pdf'
                }}).then(response => {
                    this.locations = response.data;
                }, err => {
                    console.error(err);
                    this.Message = "Er ging iets mis";
                });
        },
    }
});
