import type { AppRouteModule } from '/@/router/types'

import { LAYOUT } from '/@/router/constant'
import { t } from '/@/hooks/web/useI18n'

const about: AppRouteModule = {
  path: '/schedulerType',
  name: 'schedulerType',
  component: LAYOUT,
  redirect: '/schedulerType/index',
  meta: {
    hideChildrenInMenu: true,
    icon: 'simple-icons:about-dot-me',
    title: t('routes.dashboard.schedulerType'),
    orderNo: 100000,
  },
  children: [
    {
      path: 'index',
      name: 'schedulerType',
      component: () => import('/@/views/schedulerType/index.vue'),
      meta: {
        title: t('routes.dashboard.schedulerType'),
        icon: 'simple-icons:about-dot-me',
        hideMenu: true,
      },
    },
  ],
}

export default about
