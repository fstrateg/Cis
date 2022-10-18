<script>
    export default {
        name: "BypassItem",
        props: ['item'],
        methods: {
            getClass(vl) {
                let rez = ['grp'];
                switch (vl) {
                    case 1:
                        rez.push('grp-red');
                        break;
                    case 0:
                        rez.push('grp-green');
                        break;
                    case -1:
                        rez.push('grp-gray');
                        break;
                    case 2:
                        rez.push('grp-yellow');
                        break;

                }
                return rez;
            },
            edit(event) {
                console.log(event.target.getAttribute('data-id'));
                this.$router.push('bypassedit?id=-1');
            }
        }
    }
</script>

<template>
    <div class="row justify-content-md-center">
        <div class="col-lg-8 col-md-10 list-cn">
            <div class="list-cap"><h3>{{ item.fio }}</h3></div>
            <div class="list-det">
                <div class="row">
                    <div class="col"><b>Дата создания:</b></div>
                    <div class="col"><b>Событие:</b></div>
                    <div class="col"><b>ID в системе:</b></div>
                    <div class="col-5"><b>Примечание:</b></div>
                </div>
                <div class="row">
                    <div class="col">{{ item.docDate}}</div>
                    <div class="col">{{ item.eventName }}</div>
                    <div class="col">{{ item.zverId }}</div>
                    <div class="col-5">{{ item.remark }}</div>
                </div>
                <div class="row">
                    <div class="col">&nbsp;</div>
                    <div class="col"><b>Дата события:</b></div>
                    <div class="col"><b>Контракт:</b></div>
                    <div class="col-5"><b>Подразделение:</b></div>
                </div>
                <div class="row">
                    <div class="col">&nbsp;</div>
                    <div class="col">{{ item.eventDate }}</div>
                    <div class="col">{{ item.zverKon }}</div>
                    <div class="col-5">{{ item.staff }}</div>
                </div>
            </div>
            <div class="list-grp row">
                <div class="col">
                    <div :class="getClass(item.p138)">138</div>
                    <div :class="getClass(item.p183)">183</div>
                    <div :class="getClass(item.p314)">314</div>
                    <div :class="getClass(item.p405)">405</div>
                    <div :class="getClass(item.p778)">778</div>
                    <div :class="getClass(item.p363)">363</div>
                    <div :class="getClass(item.p124)">124</div>
                    <div :class="getClass(item.p108)">108</div>
                    <div :class="getClass(item.p758)">758</div>
                    <img class="grp-img" src="Images/loop.png" :title="item.info" />
                    <a href="javascript:(0)" @click="edit">
                        <img class="grp-img" src="Images/edit.png" title="Редактировние" :data-id="item.id"/>
                    </a>
                </div>
            </div>
        </div>

    </div>
</template>


<style scoped type="text/css">
    body {
        font-size: 14px;
    }

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

    .grp-gray {
        background: #a0a0a0;
        border: 1px solid #909090;
    }

    .grp-yellow {
        background: #f7da2a;
        border: 1px solid #ccaf00;
    }

    .grp-img {
        width: 32px;
        height: 32px;
        margin: 10px 3px;
    }
</style>
