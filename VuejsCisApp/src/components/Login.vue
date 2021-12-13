<template>
    <form class="mx-auto login-form" @submit.prevent="handleSubmit">
        <h3>Вход</h3>
        <div class="mb-3 px-5">
            <label>Пользователь</label>
            <input type="text" class="form-control" v-model="login" placeholder="Пользователь" />
        </div>
        <div class="mb-4 px-5">
            <label>Пароль</label>
            <input type="password" class="form-control" v-model="password" placeholder="Пароль" />
        </div>
        <div class="mb-4 px-5 login-form-submit">
            <button class="btn btn-primary btn-block">Вход</button>
        </div>
    </form>
</template>

<script lang="ts">
    import { Component, Vue } from 'vue-property-decorator'
    import backend from '../backend'

    @Component
    export default class Login extends Vue
    {
        private login: string = ''
        private password: string = ''

        public async handleSubmit() {
            let obj = { user: this.login, pass: this.password }
            backend.post('loginnet',obj)
                    console.log(obj)
                }
    }
</script>

<style scoped>
    .login-form-submit {
        text-align: center;
    }
    .form-control:focus{
        border-color: #167bff;
        box-shadow: none;
    }
</style>