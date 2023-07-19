<template>
  <Table :dataSource="dataSource" :columns="columns" />
</template>
<script lang="ts" setup>
  import { reactive } from 'vue'
  import { Table } from 'ant-design-vue'
  import { getSchedulerList } from '/@/api/schedulerType/index'
  import { schedulerTypeModel } from '/@/api/schedulerType/model/schedulerTypeModel'

  let schedulerTypeResponse = await getSchedulerList()

  let dataSource = reactive(schedulerTypeResponse.items as schedulerTypeModel[])
  let columns = reactive([
    {
      title: 'id',
      dataIndex: 'id',
      key: 'id',
    },
    {
      title: '名称',
      dataIndex: 'name',
      key: 'name',
    },
    {
      title: '描述',
      dataIndex: 'description',
      key: 'description',
    },
  ])
</script>
