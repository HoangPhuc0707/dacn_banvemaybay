
    Vue.config.ignoredElements = [/^ion-/]
    var app = new Vue ({
        el:'#app',
        data:{
            LoginRequest:{
                UserName:'',
                Password:''
            },
            errorMessage:'',
        },
        methods:{
            login(){
                axios.post('/api/AuthManagerment/Login',this.LoginRequest)
                    .then((reponse) => {
                        window.location.href='Flights/Index';
                    }).catch((error) => {
                        console.error(error.response.data);
                        app.errorMessage = JSON.stringify(error.response.data.errors)
                            .replace(/^\[|\]$/g, '')
                            .replace(/"/g, '');;
                    });
            },
        },
        mounted: function(){

        },
    });