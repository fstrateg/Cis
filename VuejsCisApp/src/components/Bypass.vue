<template>
    <p>Обходные новые и просроченные</p>
</template>
<script lang="ts">

    import { Component, Vue } from 'vue-property-decorator'
    import backend from '../backend'

    interface Emploee {
        Fio: string;
    }



    @Component
    export default class Bypass extends Vue {

        private Employes: Emploee[]=[];

        public async created() {
            const resp = await backend.get('cis/bypasslist', {
                headers: {
                    Autorization: 'Bearer ' + sessionStorage.getItem('token')
                }
            });

            let arr = resp.data;
            console.log(resp.data);
            
            arr.forEach(function (item: any) {
                let i = new Emploee();
                this.Employes.push()
                console.log(item);
            });
        }
    }
</script>