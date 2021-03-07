const vueApp = new Vue({
    el: '#app',
    data() {
       
        return {
            pageSize: 10,
            distance: 100,
          
        }
    },

    methods: {
        SearchLocation() {
            axios
                .post(`api/v1/pdf/invoice`, this.InvoiceRequest, {
                    responseType: 'arraybuffer',
                    headers: {
                        'Content-Type': 'application/json',
                        'Accept': 'application/pdf'
                    }
                })
                .then(response => {
                    console.log(response);

                    var blob = new Blob([response.data]);
                    var link = document.createElement('a');
                    link.href = window.URL.createObjectURL(blob);
                    link.download = "invoice.pdf";
                    link.click();

                }, err => {
                    console.error(err);
                    this.Message = "Er ging iets mis";
                });
        },    
    }
});
