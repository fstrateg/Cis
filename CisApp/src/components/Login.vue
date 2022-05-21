<template>
    <div class="auth-fon">
        <div class="auth-wrapper">
            <div class="auth-inner">
                <div class="row">
                    <div class="col-6">
                    </div>
                    <div class="col-6">
                        <form class="loging-form" @submit.prevent="handleSubmit">
                            <h3>Вход в систему</h3>
                            <p class="comment">Обходные листы</p>
                            <div class="form-group pb-3">
                                <label>Пользователь</label>
                                <input type="text" class="form-control" v-model="login" placeholder="Пользователь" />
                            </div>
                            <div class="form-group pb-3">
                                <label>Пароль</label>
                                <input type="password" class="form-control" v-model="password" placeholder="Пароль" />
                            </div>
                            <button class="btn btn-primary btn-enter">Вход</button>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>

</template>

<script>
    import backend from '../backend'
    export default
    {
            name: 'Login',
            data() {
                return {
                    login: '',
                    password: ''
                };
            },
            methods: {
                handleSubmit() {
                    let obj = { Username: this.login, Password: this.password }
                    const route = this.$router;
                    backend.post('loginnet', obj).then(function (resp) {
                        localStorage.setItem('token', resp.data.token);
                            route.push('/');
                            console.log(resp.data);
                    });
                    console.log(obj)
                }
            }
    }
</script>

<style scoped>
    .login-form-submit {
        text-align: center;
    }

    .form-control:focus {
        border-color: #167bff;
        box-shadow: none;
    }

    .form-control:focus {
        box-shadow: 0 0 4px rgb(13 110 253 / 25%)
    }

    .btn-enter {
        padding: 5px 35px;
    }

    .comment {
        font-size: 0.7rem;
    }

    .auth-fon {
        display: inline-block;
        position: absolute;
        height: 100%;
        width: 100%;
    }

    .auth-inner {
        background: url('/images/login.png') no-repeat;
        background-size: 300px;
        width: 600px;
        margin: auto;
        border: 1px solid #0d6efd;
        border-radius: 10px;
    }

    .auth-wrapper {
        display: flex;
        justify-content: center;
        flex-direction: column;
        width: 100%;
        height: 100%;
        margin: auto;
    }

    .auth-inner form {
        text-align: center;
        padding: 40px 20px;
    }

    .auth-inner .form-group {
        text-align: start !important;
    }
</style>