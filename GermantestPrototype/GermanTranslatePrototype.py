from kivy.app import App
from kivy.uix.button import Button
from kivy.uix.label import Label
from kivy.uix.boxlayout import BoxLayout
from kivy.uix.screenmanager import ScreenManager, Screen
from random import randint
word = None
words = [["guckt an"],  ["titta"], ["ganze"], ["hela"], ["deswegen"], ["därför"], ["halten"], ["hålla"],
["sofort"], ["genast"], ["ruf an"], ["ringa"], ["nie"], ["aldrig"], ["stottern"], ["stamma"],
["dringend"], ["bråttom"], ["Schlimste"], ["värsta"], ["reden"], ["prata"], ["unangenehm"], ["obehagligt"],
["Angst"], ["rädsla"]
]

class germanScr(Screen):
    def __init__(self, name="german"):
        super().__init__(name=name)
        self.main_box = BoxLayout(orientation="vertical", padding=8, spacing=8)
        self.upper_box = BoxLayout(orientation="vertical", padding=8, spacing=8)
        self.down_box = BoxLayout(orientation="horizontal", padding=8, spacing=8)
        self.next_word = Button(text="Next word")
        self.btn_translation = Button(text="Show translation")
        self.word_in_germ = Label(font_size="50sp")

        self.next_word.on_press = self.create_word
        self.btn_translation.on_press = self.show_translation

        self.upper_box.add_widget(self.word_in_germ)
        self.down_box.add_widget(self.next_word)
        self.down_box.add_widget(self.btn_translation)

        self.main_box.add_widget(self.upper_box)
        self.main_box.add_widget(self.down_box)

        self.add_widget(self.main_box)
    def on_pre_enter(self, *args):
        self.create_word()
        return super().on_pre_enter(*args)
    def create_word(self):
        global words
        global word
        word = randint(0, len(words) - 1)
        print(word)
        while word%2 != True:
            word = randint(0, len(words) -1)
        print(words[word -1])
        self.word_in_germ.text = (str(*words[word-1]))
    def show_translation(self):
        self.manager.transition.direction = "left"
        self.manager.current = "swedish"
class SwedScr(Screen):
    def __init__(self, name="swedish"):
        super().__init__(name=name)
        self.main_box = BoxLayout(orientation="vertical", padding=8, spacing=8)
        self.upper_box = BoxLayout(orientation="vertical", padding=8, spacing=8)
        self.down_box = BoxLayout(orientation="horizontal", padding=8, spacing=8)
        self.btn_back = Button(text="Go back")
        self.swed_word = Label(font_size='50sp')

        self.btn_back.on_press = self.go_back

        self.upper_box.add_widget(self.swed_word)
        self.down_box.add_widget(self.btn_back)

        self.main_box.add_widget(self.upper_box)
        self.main_box.add_widget(self.down_box)

        self.add_widget(self.main_box)
    def on_pre_enter(self, *args):
        global words
        global word
        self.swed_word.text = str(*words[word])
        return super().on_pre_enter(*args)
    def go_back(self):
        self.manager.transition.direction = "right"
        self.manager.current = "german"
class TranslateGerman(App):
    def build(self):
        sm = ScreenManager()
        sm.add_widget(germanScr())
        sm.add_widget(SwedScr())

        return sm

app = TranslateGerman()
app.run()   