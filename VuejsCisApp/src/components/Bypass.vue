<template>
    <div>
        <p>Обходные новые и просроченные</p>
        <ul id="v-for-object" class="demo">
            <li v-for="value in Employes">
                {{ value }}
            </li>
        </ul>
    </div>
</template>
<script lang="ts">

    import { Component, Vue } from 'vue-property-decorator'
    import backend from '../backend'

    interface Emploee {
        Fio: string;
    }



    @Component
    export default class Bypass extends Vue {

        private Employes: Emploee[] = [];

        public async created() {
            console.log(sessionStorage.getItem('token'));
            const resp = await backend.get('cis/bypasslist');
            

            let arr: Array<any> = resp.data;
            

            for (let i = 0; i < arr.length; i++)
                this.Employes.push(arr[i].objCaption);
            console.log(arr[0].objCaption);
        }
    }
</script>