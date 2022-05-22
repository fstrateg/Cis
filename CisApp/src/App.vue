<template>
    <div id="app">
        <Nav :key="$route.fullPath"/>
        <router-view />
    </div>
</template>

<script>

    import Nav from './components/Nav.vue';

    export default {
        name: 'app',
        data() {
            return{
                isLogining: false
            }
        },
        components: {
            Nav
        },
    };
</script>

<style>
</style>

