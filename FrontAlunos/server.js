const express = require('express');
const path = require('path');
const nomeApp = 'FrontAlunos';
const app = express();

app.use(express.static(`${__dirname}/dist/${nomeApp}`));

app.get('/*', (req, res) => {
  res.sendFile(path.join(`${__dirname}/dist/${nomeApp}/index.html`));
});

const port = process.env.PORT || 8080;
app.listen(port, () => {
  console.log(`Server listening on port ${port}`);
});
