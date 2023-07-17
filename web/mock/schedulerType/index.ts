import { resultSuccess, resultError, getRequestToken, requestParams } from '../_util'
import { MockMethod } from 'vite-plugin-mock'

// single
function getSchedulerList() {
  return {
    items: [
      { id: 1, name: 'api任务', description: 'api task desc' },
      { id: 2, name: '应用程序任务', description: 'application task desc' },
    ],
    total: 20,
  }
}

export default [
  {
    url: '/basic-api/api/app/schedulerType',
    timeout: 1000,
    method: 'get',
    response: (request: requestParams) => {
      const token = getRequestToken(request)
      if (!token) {
        return resultError('Invalid token!')
      }

      const menu: Object = getSchedulerList()

      return resultSuccess(menu)
    },
  },
] as MockMethod[]
