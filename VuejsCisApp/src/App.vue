<template>
    <div id="app">
        <Nav />
        <div class="auth-wrapper">
            <div class="auth-inner">
                <router-view />
            </div>
        </div>
    </div>
</template>

<script lang="ts">
    import { Component, Vue } from 'vue-property-decorator'
    import Nav from './components/Nav.vue'

    @Component({
        components: {
            Nav
        }
    })
    export default class App extends Vue { }
</script>

<style>
        body, html, #app, .auth-wrapper{
            width:100%;
            height:100%;
        }
        .auth-wrapper{
            display: flex;
            justify-content: center;
            flex-direction: column;
            text-align: left;
        }

        .auth-wrapper h3{
            text-align: center;
            margin:0;
            line-height: 1;
            padding-bottom: 20px;
        }
        .auth-inner{
            width: 450px;
            margin: auto;
            background: #f0f0f0;
            box-shadow: 0px 14px 80px rgba(34,3,58,0.2);
            padding: 40px 55px 45px 55px;
            border-radius: 15px;
            transition: all .3s;
            border: solid 1px #c0c0ff
        }
</style>
