<template>
    <div class="container">
        <h3 class="title">Архив обходных</h3>
        <div class="row">
            <div class="col2" id="filter">
                c: <el-date-picker v-model="datfrom"
                                   type="date"
                                   placeholder="Pick a day"
                                   format="dd.MM.yyyy"
                                   ></el-date-picker>
                по: <el-date-picker v-model="datto"
                                    type="date"
                                    placeholder="Pick a day"
                                    format="dd.MM.yyyy"></el-date-picker>
                ФИО начинается:
                <el-input v-model="fio"></el-input>&nbsp;
                <el-button type="primary" icon="el-icon-refresh" @click="refresharchive"></el-button>
            </div>
        </div>
        <el-table :data="table"
                  :default-sort="{prop: 'docDate', order: 'descending'}"
                  :cell-style="{padding: '6px 0'}"
                  style="width: 100%">
            <el-table-column prop="docDate"
                             label="Дата"
                             sortable
                             width="100">
            </el-table-column>
            <el-table-column prop="event"
                             label="Событие"
                             sortable
                             width="140">
            </el-table-column>
            <el-table-column prop="fio"
                             label="ФИО"
                             sortable
                             width="300">
            </el-table-column>
            <el-table-column label="Подразделение|Должность"
                             sortable
                             width="250">
                <template slot-scope="scope">
                    <span class="cellwrap">{{ scope.row.staff }}</span>
                </template>
            </el-table-column>
            <el-table-column prop="remark"
                             label="Примечание"
                             sortable
                             >
                <template slot-scope="scope">
                    <span class="cellwrap">{{ scope.row.remark }}</span>
                </template>
            </el-table-column>

        </el-table>

    </div>
</template>

<script>
    import moment from 'moment';
import { getBackend } from '../backend'

    export default {
        name: 'Archive',
        data() {
            return {
                datfrom: null,
                datto: null,
                fio: null,
                table: []
            };
        },
        created() {
            console.log(moment());
            this.datto = moment().format('YYYY-MM-DD');
            this.datfrom = moment().subtract(1, 'month').format('YYYY-MM-DD');
            console.log(this.datto);
        },
        methods: {
            async refresharchive() {
                const backend = getBackend();
                const resp = await backend.post('cis/archive',
                    {
                        datefrom: this.datfrom,
                        dateto: this.datto,
                        fio: this.fio
                    });
                this.table = resp.data;
                console.log(resp)
            },
            
        }
    };
</script>

<style scoped>
    #filter{
        padding-top:20px;
    }
    .el-date-editor.el-input
    {
        width: 150px;
    }
    .el-input{
        width: 260px;
    }
    .el-table{
        font-size: 11px;
        padding-top: 20px;
    }
        span.cellwrap{
            white-space: nowrap;
        }
    td.table-row {
        padding: 6px 0
    }
</style>

