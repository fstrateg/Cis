<template>
    <div class="home">
        <h3 class="title">Обходные новые и просроченные</h3>
            <div v-for="item in Employes" :key="item.id">
                <BypassItem :item=item />
            </div>
    </div>
</template>

<script>
    import { getBackend } from '../backend'
    import BypassItem from '../components/BypassItem'

    export default {
        name: 'Bypass',
        components: {
            BypassItem: BypassItem
        },
        data() {
            return {
                Employes: []
            };
        },
        async mounted() {

            const backend = getBackend();
            const resp = await backend.get('cis/bypasslist');


            let arr = resp.data;


            for (let i = 0; i < arr.length; i++) {
                let item = arr[i];
                this.Employes.push({
                    id: item.id,
                    fio: item.objCaption,
                    docDate: item.docDate,
                    eventDate: item.eventDate,
                    eventName: item.typeName,
                    zverId: item.zverid,
                    zverKon: item.zverContract,
                    staff: item.staff,
                    remark: item.remark,
                    p108: item.p108,
                    p124: item.p124,
                    p138: item.p138,
                    p183: item.p183,
                    p314: item.p314,
                    p363: item.p363,
                    p405: item.p405,
                    p758: item.p758,
                    p778: item.p778,
                    info: item.info
                });
            }
            console.log(arr[0]);
        }
    };
</script>

<style scoped type="text/css">
    

    .list-tb {
    }

    .list-cn {
        border: 1px solid #4857ff;
        padding: 4px;
        margin-top: 25px;
        border-radius: 5px;
        background: #fcfcff;
        box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
    }

    .list-cap {
        text-align: center;
    }

    .list-det {
        margin: 0px 20px;
        padding: 15px 5px;
        border-top: 1px solid #4857ff;
        border-bottom: 1px solid #4857ff;
    }

    .list-grp .col {
        display: inline-flex;
        justify-content: center;
    }

    .grp {
        display: flex;
        align-items: center;
        justify-content: center;
        font-size: 12px;
        color: #fff;
        font-weight: bold;
        height: 32px;
        width: 32px;
        margin: 10px 3px;
        border-radius: 3px;
        box-shadow: 0 2px 4px 0 rgba(0, 0, 0, 0.2), 0 3px 10px 0 rgba(0, 0, 0, 0.19);
    }

    .grp-green {
        background: #38E538;
        border: 1px solid #38D538;
    }

    .grp-red {
        background: #FF3636;
        border: 1px solid #D53636;
    }
</style>
