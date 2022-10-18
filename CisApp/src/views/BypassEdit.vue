<script>
    export default {
        name: 'BypassEdit',
        data() {
            return {
                id: undefined,
                docDate: undefined,
                eventId: "",
                remark: ""
            }
        },
        created() {
            this.id = this.$route.query.id;
        }
    }
</script>

<template>
    <div class="row justify-content-md-center">
        <h3 class="title">Редактирование ID={{id}}</h3>
        <div class="col-lg-8 col-md-10 list-cn">
            <form>
                <div class="row">
                    <div class="col-3">
                        <div class="ed-ico"></div>
                    </div>
                    <div class="col-9">
                        <div class="row mb-3">
                            <label class="col-sm-2 col-form-label">Действие:</label>
                            <div class="col-sm-10">
                                <el-input v-model="eventId"></el-input>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <label class="col-sm-2 col-form-label">Дата:</label>
                            <div class="col-sm-10">
                                <el-date-picker class="col-sm-6"
                                                v-model="docDate"
                                                type="date"
                                                placeholder="Pick a day"
                                                format="dd.MM.yyyy"></el-date-picker>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <label class="col-sm-2 col-form-label">Сотрудник:</label>
                            <div class="col-sm-10">
                                <el-input></el-input>
                            </div>
                        </div>
                        <div class="row">
                            <label class="col-sm-2">Примечание:</label>
                            
                        </div>
                        <div class="row mb-3">
                            <div class="col">
                                <el-input v-model="remark"></el-input>
                            </div>
                        </div>
                    </div>
                   
                </div>
                <table id="tab" class="table table-bordered">
                    <thead>
                        <th>Исключить</th>
                        <th>Наименование параметра</th>
                        <th>Параметр</th>
                    </thead>
                    <tbody id="tab-body">
                        <tr>
                            <td></td>
                            <td>Бухгалтерия</td>
                            <td>312</td>
                        </tr>
                    </tbody>
                </table>
            </form>
        </div>
    </div>
</template>



<style>
    #tab>thead {
        border-bottom: 1px solid #4857ff;
    }
    #tab>tbody {
        border-top: 1px;
    }
    .ed-ico {
        background: url('/images/edit-e.png') no-repeat;
        background-size: contain;
        width: 100%;
        height: 100%;
        display: block;
    }
    .list-cn {
        border: 1px solid #4857ff;
        padding: 20px;
        margin-top: 25px;
        border-radius: 5px;
        background: #fcfcff;
        box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
    }

</style>