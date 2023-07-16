import { resultSuccess, resultError, getRequestToken, requestParams } from '../_util'
import { MockMethod } from 'vite-plugin-mock'

// single
function getSchedulerList() {
  return {
    items: [],
    total: 20,
  }
}

export default [
  {
    url: '/api/app/schdulerType',
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
