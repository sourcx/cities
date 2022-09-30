import Header from './header/header.js'
import Content from './content/content.js'
import Footer from './footer/footer.js'

const App = {
  components: {
    'app-header': Header,
    'app-content': Content,
    'app-footer': Footer
  },

  mounted () {
    console.log('Application mounted.')
  }
}

window.addEventListener('load', () => {
  const { createApp } = Vue
  createApp(App).mount("#main")
})
