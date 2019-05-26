#include "widget.h"
#include "ui_widget.h"
#include <QFileDialog>
#include <QDir>
#include <QSlider>
#include <QtWidgets>
#include <QToolButton>

Widget::Widget(QWidget *parent) :
    QWidget(parent),
    ui(new Ui::Widget)
{
    ui->setupUi(this);
    // Настройка таблиці плейліста
    m_playListModel = new QStandardItemModel(this);
    ui->playlistView->setModel(m_playListModel);    // Встановлюємо модель даннх в TableView
    // Встановлюємо заголовки таблиці
    m_playListModel->setHorizontalHeaderLabels(QStringList()  << tr("Audio Track")
                                                            << tr("File Path"));
    ui->playlistView->hideColumn(1);    // Приберемо колонку в якій зберігається шлях до файлів
    ui->playlistView->setSelectionBehavior(QAbstractItemView::SelectRows);  //Включаємо виділення пісні
    ui->playlistView->setSelectionMode(QAbstractItemView::SingleSelection); // Дозволяємо виділяти лише одну пісню
    ui->playlistView->setEditTriggers(QAbstractItemView::NoEditTriggers);   // Відключаємо редагування назв пісень
    //Підганяємо розмір вікна з плейліста під довжину назви пісні
    ui->playlistView->horizontalHeader()->setStretchLastSection(true);

    m_player = new QMediaPlayer(this);          // Ініціалізую плеєр
    m_playlist = new QMediaPlaylist(m_player);  // Ініціалізую плейліст
    m_player->setPlaylist(m_playlist);    //встановлюю плейліст в плеєр
    m_player->setVolume(70);    // встановлюю гучність
    m_playlist->setPlaybackMode(QMediaPlaylist::Loop);  // встановлюю циклічніст підключаю кнопки управління до слотів управління

    //connect(ui->verticalSlider, SIGNAL(valueChanged(int)), m_player, SLOT(setValue(int)));

    connect(ui->btn_previous, &QToolButton::clicked, m_playlist, &QMediaPlaylist::previous);
    connect(ui->btn_next, &QToolButton::clicked, m_playlist, &QMediaPlaylist::next);
    connect(ui->btn_play, &QToolButton::clicked, m_player, &QMediaPlayer::play);
    connect(ui->btn_pause, &QToolButton::clicked, m_player, &QMediaPlayer::pause);
    connect(ui->btn_stop, &QToolButton::clicked, m_player, &QMediaPlayer::stop);

    //при додаванні треку в таблицю встановлюю трек в плейліст
    connect(ui->playlistView, &QTableView::doubleClicked, [this](const QModelIndex &index){
        m_playlist->setCurrentIndex(index.row());


    });
}

Widget::~Widget()
{
    delete ui;
    delete m_playListModel;
    delete m_playlist;
    delete m_player;
}

void Widget::on_btn_add_clicked()
{
    //робимо багатовибіркову кількість mp3 файлів
    QStringList files = QFileDialog::getOpenFileNames(this,
                                                      tr("Open files"),
                                                      QString(),
                                                      tr("Audio Files (*.mp3)"));

    //встановлюємо дані по іменам і шляхи до файлів
    //в плейліст і таблицу відображаючу плейліст
    foreach (QString filePath, files) {
        QList<QStandardItem *> items;
        items.append(new QStandardItem(QDir(filePath).dirName()));
        items.append(new QStandardItem(filePath));
        m_playListModel->appendRow(items);
        m_playlist->addMedia(QUrl(filePath));
    }
}
