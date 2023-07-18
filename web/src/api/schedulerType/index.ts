import { defHttp } from '/@/utils/http/axios'
import { schedulerTypeModel } from './model/schedulerTypeModel'
import { BasicFetchResult } from '../model/baseModel'

enum Api {
  GetList = '/api/app/schedulerType',
}

/**
 * @description: Get user menu based on id
 */

export function getSchedulerList() {
  return defHttp.request<BasicFetchResult<schedulerTypeModel>>({ url: Api.GetList, method: 'GET' })
}
