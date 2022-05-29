<template>
    <nav class="navbar navbar-expand-lg navbar-light bg-light">
        <div class="container-fluid">
            <span class="navbar-brand mb-0 h1">Обходные</span>
            <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarNav">
                <ul v-if="isLogining" class="navbar-nav  ms-auto">
                    <li class="nav-item">
                        <router-link class="nav-link" to="/">Обходные</router-link>
                    </li>
                    <li class="nav-item">
                        <router-link class="nav-link" to="/archive">Архив</router-link>
                    </li>
                    <li class="nav-item d-flex">
                        <a href="javascript: void(0)" @click="handleClick" class="nav-link" to="/login">Выход</a>
                    </li>
                </ul>
                <ul v-else class="navbar-nav  ms-auto">
                    <li class="nav-item d-flex">
                        <router-link class="nav-link" to="/login">Вход</router-link>
                    </li>
                </ul>
            </div>
        </div>
    </nav>
</template>
<script>
    import { logoutUser, isLoggedIn } from '../libs/auth'
    export default {
        name: "Nav",
        data() {
            return {
                isLogining: false
            }
        },
        methods: {
            handleClick() {
                logoutUser();
                this.$forceUpdate();
                this.$router.push('/login');
            }
        },
        mounted: function () {
            this.isLogining=isLoggedIn();
        },
        updated: function () {
            this.isLogining = isLoggedIn();
        }
    }
</script>

<style>
    .navbar {
        border-bottom: 1px solid #4857ff;
        box-shadow: 0 4px 8px 0 rgb(0 0 0 / 20%), 0 6px 20px 0 rgb(0 0 0 / 19%)
    }
</style>