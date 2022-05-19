<template>
    <div id="app">
        <Nav />
        <router-view />
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
</style>
