import { AppPage } from './app.po';

describe('service-stack-with-docker App', () => {
  let page: AppPage;

  beforeEach(() => {
    page = new AppPage();
  });

  it('should display welcome message', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('ServiceStackWithDocker');
  });
});
